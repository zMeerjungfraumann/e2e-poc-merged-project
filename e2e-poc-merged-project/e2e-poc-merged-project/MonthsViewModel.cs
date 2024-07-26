using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e2e_poc_merged_project
{
    public class MonthsViewModel{

        public ObservableCollection<string> Months { get; set; }

        public MonthsViewModel()
        {
            Months = new ObservableCollection<string>
            {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            };
        }


    }
}
