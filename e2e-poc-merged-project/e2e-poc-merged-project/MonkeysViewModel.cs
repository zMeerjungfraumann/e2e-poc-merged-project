using System.Collections.ObjectModel;
using System.ComponentModel;

namespace e2e_poc_merged_project
{
    public class MonkeysViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Monkey> Monkeys { get; set; }

        private Monkey currentItem;
        public Monkey CurrentItem
        {
            get => currentItem;
            set
            {
                if (currentItem != value)
                {
                    currentItem = value;
                    OnPropertyChanged(nameof(CurrentItem));
                }
            }
        }

        public MonkeysViewModel()
        {
            Monkeys = new ObservableCollection<Monkey>
            {
                new Monkey("Affe 1","Dschungel", "Ein lustiger Affe", "orangutan.jpg"),
                new Monkey("Affe 2", "Jungle", "A funny monkey", "monkey2.jpg"),
                new Monkey("Affe 3", "Jungle", "A funny monkey", "monkey3.jpg"),
                new Monkey("Affe 4", "Jungle", "A funny monkey", "monkey4.jpg"),
                new Monkey("Affe 5", "Jungle", "A funny monkey", "monkey5.jpg"),
                new Monkey("Affe 6", "Jungle", "A funny monkey", "monkey6.jpg"),
                new Monkey("Affe 7", "Jungle", "A funny monkey", "monkey7.jpg"),
                new Monkey("Affe 8", "Jungle", "A funny monkey", "monkey8.jpg"),
                new Monkey("Affe 9", "Jungle", "A funny monkey", "monkey9.jpg"),
                new Monkey("Affe 10", "Jungle", "A funny monkey", "monkey10.jpg")
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}