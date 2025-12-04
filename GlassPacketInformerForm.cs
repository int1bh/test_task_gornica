using System.Text;
using System.Text.RegularExpressions;

namespace GlassPacketInformer
{
    public partial class GlassPacketInformerForm : Form
    {
        public GlassPacketInformerForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void InfoBtnClick(object sender, EventArgs e)
        {
            string article = inputField.Text.Trim();

            try
            {
                string result = AnalyzeGlassPackage(article);
                outputField.Text = result;
                outputField.SelectionStart = 0;
                outputField.SelectionLength = 0;
            }
            catch (Exception ex)
            {
                outputField.Text = $"Ошибка: {ex.Message}";
            }
        }

        private string AnalyzeGlassPackage(string article)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Артикул: {article}");
            result.AppendLine(new string('=', 50));
            result.AppendLine();

            // Разделяем артикул по символу "/"
            string[] parts = article.Split('/');

            if (parts.Length < 3 || parts.Length > 5)
            {
                throw new Exception($"Неверный формат артикула. Ожидается 3 или 5 частей, получено: {parts.Length}");
            }

            // Определяем камерность
            int chambers = parts.Length == 3 ? 1 : 2;
            result.AppendLine($"1. Камерность: {(chambers == 1 ? "однокамерный" : "двухкамерный")} СП");

            // Парсим толщины всех элементов
            int[] thicknesses = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                thicknesses[i] = ExtractThickness(parts[i]);
            }

            // Выводим детальную информацию о структуре
            result.AppendLine();
            result.AppendLine("Структура стеклопакета:");
            if (chambers == 1)
            {
                result.AppendLine($"   Стекло: {thicknesses[0]} мм");
                result.AppendLine($"   Камера: {thicknesses[1]} мм");
                result.AppendLine($"   Стекло: {thicknesses[2]} мм");
            }
            else
            {
                result.AppendLine($"   Стекло: {thicknesses[0]} мм");
                result.AppendLine($"   Камера 1: {thicknesses[1]} мм");
                result.AppendLine($"   Стекло: {thicknesses[2]} мм");
                result.AppendLine($"   Камера 2: {thicknesses[3]} мм");
                result.AppendLine($"   Стекло: {thicknesses[4]} мм");
            }

            result.AppendLine();

            // Суммируем все толщины для общей толщины СП
            int totalThickness = thicknesses.Sum();
            result.AppendLine($"2. Толщина СП: {totalThickness} мм");

            // Суммируем толщины только стекол (элементы на позициях 0, 2, и если есть - 4)
            int glassThickness = thicknesses[0] + thicknesses[2];
            if (chambers == 2)
            {
                glassThickness += thicknesses[4];
            }
            result.AppendLine($"3. Толщина стекла: {glassThickness} мм");

            return result.ToString();
        }

        private int ExtractThickness(string part)
        {
            if (string.IsNullOrWhiteSpace(part))
            {
                return 0;
            }

            // Убираем пробелы в начале и конце
            part = part.Trim();

            // Используем регулярное выражение для извлечения числа в начале строки
            // Ищем одно или двухзначное число в начале строки
            Match match = Regex.Match(part, @"^\d{1,2}");

            if (match.Success && int.TryParse(match.Value, out int thickness))
            {
                return thickness;
            }

            // Если не нашли число в начале, пытаемся найти первое число в строке
            Match firstNumber = Regex.Match(part, @"\d{1,2}");
            if (firstNumber.Success && int.TryParse(firstNumber.Value, out int firstThickness))
            {
                return firstThickness;
            }

            throw new Exception($"Не удалось извлечь толщину из части: {part}");
        }
    }
}
