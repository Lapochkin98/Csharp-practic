using System.Windows.Forms;

namespace Day18TasksPart2.Entities
{
    class ControlArray<T> where T : Control, new()
    {
        private readonly T[] _controls;

        public ControlArray(int count, int width, int height)
        {
            _controls = new T[count];
            for (int i = 0; i < count; i++)
            {
                _controls[i] = new T();
                _controls[i].Width = width;
                _controls[i].Height = height;
            }
        }

        public void DisplayOnForm(Form form, int x, int y, int spacing)
        {
            int currentX = x;
            int currentY = y;
            foreach (T control in _controls)
            {
                control.Location = new System.Drawing.Point(currentX, currentY);
                form.Controls.Add(control);
                currentX += control.Width + spacing;
            }
        }
    }
}