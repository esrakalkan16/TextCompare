using DocumentFormat.OpenXml.Packaging;
using OfficeOpenXml;

namespace RdsTextCompare1
{
    public partial class Form1 : Form
    {
        private string fileContent1;
        private string fileContent2;

        public List<string> Metinn1 { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                fileContent1 = ReadFileContent(filePath);
                rtbFileContent1.Text = fileContent1;

            }
        }

        private void btnSelectFile2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                fileContent2 = ReadFileContent(filePath);
                rtbFileContent2.Text = fileContent2;
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbFileContent1.Text) || string.IsNullOrWhiteSpace(rtbFileContent2.Text))
            {
                MessageBox.Show("Ýki alan da dolu olmalýdýr");
            }
            else
            {
                CompareTexts(rtbFileContent1, rtbFileContent2);

            }
        }

        private string ReadFileContent(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            switch (extension)
            {
                case ".txt":
                    return File.ReadAllText(filePath);
                case ".docx":
                    return ReadWordFile(filePath);
                case ".xlsx":
                    return ReadExcelFile(filePath);
                case ".csv":
                    return File.ReadAllText(filePath);
                case ".html":
                    return File.ReadAllText(filePath);
                default:
                    throw new NotSupportedException("Unsupported file type");
            }
        }

        private string ReadWordFile(string filePath)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                return wordDoc.MainDocumentPart.Document.Body.InnerText;
            }
        }

        private string ReadExcelFile(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                var content = new StringWriter();
                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= colCount; col++)
                    {
                        content.Write(worksheet.Cells[row, col].Text + "\t");
                    }
                    content.WriteLine();
                }
                return content.ToString();
            }
        }




        private void CompareTexts(RichTextBox rtb1, RichTextBox rtb2)
        {
            List<string> Metin1 = new List<string>();
            List<string> Metin2 = new List<string>();

            int A = rtb1.Lines.Count();
            int B = rtb2.Lines.Count();

            // Metin1 ve Metin2'yi satýr sayýsýna göre belirleme
            if (A <= B)
            {
                Metin1 = rtb1.Lines.ToList();
                Metin2 = rtb2.Lines.ToList();
            }
            else
            {
                Metin1 = rtb2.Lines.ToList();
                Metin2 = rtb1.Lines.ToList();
            }

            List<string> TutucuMetin1 = new List<string>();
            List<string> DiffList = new List<string>();
            int offset = 0;

            for (int i = 0; i < Metin1.Count; i++)
            {
                int currentMetin2Index = i + offset;

                if (currentMetin2Index < Metin2.Count)
                {
                    if (Metin1[i] == Metin2[currentMetin2Index])
                    {
                     
                        TutucuMetin1.Add(Metin1[i]);
                    }
                    else
                    {

                        // Farklý olan satýrlarý geçici listeye ekle
                        DiffList.Add("*" + Metin2[currentMetin2Index]);
                        offset++;

                        // Ýç döngü, eþleþme bulana kadar farklý satýrlarý toplar
                        while (currentMetin2Index < Metin2.Count)
                        {
                            currentMetin2Index = i + offset;

                            if (currentMetin2Index < Metin2.Count && Metin1[i] == Metin2[currentMetin2Index])
                            {
                                TutucuMetin1.AddRange(DiffList);
                                DiffList.Clear(); // Listeyi temizle
                                TutucuMetin1.Add(Metin1[i]);
                                break;
                                
                            }
                            else if (currentMetin2Index < Metin2.Count)
                            {
                                DiffList.Add("*" + Metin2[currentMetin2Index]);
                                offset++;
                            }
                            else
                            {
                                break;
                               
                                
                            }

                        }
                 

                    }
                }
                else
                {
                    break;
                }
            }

            // Satýr sayýsý az olan metni temizleyip, sonuçlarý oraya yazdýrma
            if (A <= B)
            {
                rtb1.Clear();
                foreach (var satir in TutucuMetin1)
                {
                    rtb1.AppendText(satir + "\n");
                }
            }
            else
            {
                rtb2.Clear();
                foreach (var satir in TutucuMetin1)
                {
                    rtb2.AppendText(satir + "\n");
                }
            }
        }



        private void rtbFileContent2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void rtbFileContent2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }



}

