using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace light_backup_tool
{
    class Controller
    {
        private MainWindow window;
        public Controller(MainWindow window)
        {
            this.window = window;
        }
        public void setProgressBar(int value)
        {
            window.setProgressBar(value);
        }

        public void addToProgressBar(int value)
        {
            window.addToProgressBar(value);
        }

        public void sendError(String message)
        {
            window.showError(message);
        }
    }
}
