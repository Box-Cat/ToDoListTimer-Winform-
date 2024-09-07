using System.Diagnostics;
using System.Windows.Forms;
using System.Text.Json;


namespace ToDoTimer
{
    public partial class Form1 : Form
    {
        private Dictionary<int, Stopwatch> timers = new Dictionary<int, Stopwatch>();
        private Dictionary<int, System.Windows.Forms.Timer> timerUpdaters = new Dictionary<int, System.Windows.Forms.Timer>(); 
        private string filePath = "timers.dat";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewTimer.CellClick += dataGridViewTimer_CellClick;
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists("data.json"))
            {
                var json = File.ReadAllText("data.json");
                var data = JsonSerializer.Deserialize<List<TimerData>>(json);

                dataGridViewTimer.Rows.Clear();

                foreach (var row in data)
                {
                    Debug.WriteLine(row.ToDo); // 디버깅용 출력
                    dataGridViewTimer.Rows.Add(row.ToDo, row.StartDate, row.TargetDate, row.TargetTime, row.TimeElapsed);
                }
            }
        }

        private void SaveData()
        {
            var data = new List<object>();
            foreach (DataGridViewRow row in dataGridViewTimer.Rows)
            {
                if (!row.IsNewRow)
                {
                    var rowData = new
                    {
                        ToDo = row.Cells["toDo"].Value?.ToString(),
                        StartDate = row.Cells["startDate"].Value?.ToString(),
                        TargetDate = row.Cells["targetDate"].Value?.ToString(),
                        TargetTime = row.Cells["targetTime"].Value?.ToString(),
                        TimeElapsed = row.Cells["timeElapsed"].Value?.ToString()
                    };
                    data.Add(rowData);
                }
            }

            var json = JsonSerializer.Serialize(data);
            File.WriteAllText("data.json", json);
        }

       

        private void textBoxToDo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                dateTimePickerStart.Focus();
            }
        }

        private void textBoxTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnRegister.Focus();
            }
        }


        private void btnInit_Click(object sender, EventArgs e)
        {
            textBoxToDo.Text = "";
            dateTimePickerStart.Text = "";
            dateTimePickerEnd.Text = "";
            maskedTextTime.Text = "";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (textBoxToDo.Text == "" || maskedTextTime.Text == "    :  :")
            {
                MessageBox.Show("모든 값들을 입력해주세요");
                return;
            }

            string toDo = textBoxToDo.Text;
            string startDate = dateTimePickerStart.Text;
            string targetDate = dateTimePickerEnd.Text;
            string targetTime = maskedTextTime.Text;
            string TimeElapsed = "00:00:00";

            if (targetTime.Contains(' '))
            {
                targetTime = targetTime.Replace(" ", "0");
            }

            dataGridViewTimer.Rows.Add(toDo, startDate, targetDate, targetTime, TimeElapsed);

            textBoxToDo.Clear();
            dateTimePickerStart.Value = DateTime.Now;
            dateTimePickerEnd.Value = DateTime.Now;
            maskedTextTime.Clear();

            SaveData();
        }

        private void textBoxTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자 또는 백스페이스만 허용
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // 입력을 차단
            }
        }

        private void maskedTextTime_TextChanged(object sender, EventArgs e)
        {
            string input = maskedTextTime.Text;
            int hours = 0;
            int minutes = 0;

            // 입력 형식이 맞는지 확인
            if (input.Length >= 5 &&
                int.TryParse(input.Substring(0, 4), out hours) &&
                int.TryParse(input.Substring(5, 2), out minutes))
            {
                // 시간과 분 유효성 검증
                if (hours < 0 || hours > 9999 || minutes < 0 || minutes > 59)
                {
                    MessageBox.Show("입력 값이 유효하지 않습니다. 시간을 0-9999, 분을 0-59로 입력해주세요.");
                    maskedTextTime.Text = "0000:00";
                }
            }
        }

        private void dataGridViewTimer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 시작 버튼
            if (e.ColumnIndex == dataGridViewTimer.Columns["timerStart"].Index)
            {
                int rowIndex = e.RowIndex;

                if (rowIndex >= 0 && !timers.ContainsKey(rowIndex))
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    timers[rowIndex] = stopwatch;

                    // 실시간 시간 갱신을 위한 타이머 설정
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 1000; 
                    timer.Tick += (s, args) => UpdateElapsedTime(rowIndex);
                    timer.Start();

                    timerUpdaters[rowIndex] = timer; 
                }

                if(dataGridViewTimer.Rows[rowIndex].Cells["timeElapsed"].Value.ToString() == dataGridViewTimer.Rows[rowIndex].Cells["TargetTime"].Value.ToString().Split(':')[0])
                {
                    MessageBox.Show($"{dataGridViewTimer.Rows[rowIndex].Cells["toDo"]} - 목표 달성!");
                }

            }
            // 정지 버튼
            else if (e.ColumnIndex == dataGridViewTimer.Columns["timerStop"].Index)
            {
                int rowIndex = e.RowIndex;

                if (timers.ContainsKey(rowIndex))
                {
                    Stopwatch stopwatch = timers[rowIndex];
                    stopwatch.Stop();
                  
                    timers.Remove(rowIndex);

                    // 실시간 업데이트 타이머 중지
                    if (timerUpdaters.ContainsKey(rowIndex))
                    {
                        timerUpdaters[rowIndex].Stop();
                        timerUpdaters.Remove(rowIndex);
                    }

                    SaveData();
                }
            }
        }

        private void UpdateElapsedTime(int rowIndex)
        {
            if (timers.ContainsKey(rowIndex))
            {
                Stopwatch stopwatch = timers[rowIndex];
                TimeSpan oneSecond = TimeSpan.FromSeconds(1); //1초만 경과

                // 기존 시간 가져오기
                string existingTimeText = dataGridViewTimer.Rows[rowIndex].Cells["timeElapsed"].Value?.ToString() ?? "00:00:00";
                TimeSpan existingTime;
                TimeSpan.TryParse(existingTimeText, out existingTime);

                // 기존 시간과 현재 경과 시간을 합산
                TimeSpan totalElapsed = existingTime + oneSecond;
                dataGridViewTimer.Rows[rowIndex].Cells["timeElapsed"].Value = totalElapsed.ToString(@"hh\:mm\:ss");
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTimer.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedCell = dataGridViewTimer.SelectedCells[0];
                int rowIndex = selectedCell.RowIndex;

                if (rowIndex >= 0)
                {
                    dataGridViewTimer.Rows.RemoveAt(rowIndex);
                }

                SaveData();
            }
            else
            {
                MessageBox.Show("삭제할 셀을 선택해 주세요.");
            }
        }
    }
}
