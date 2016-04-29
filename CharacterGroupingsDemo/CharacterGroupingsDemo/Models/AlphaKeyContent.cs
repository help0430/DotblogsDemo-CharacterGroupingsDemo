using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGroupingsDemo.Models {
    public class AlphaKeyContent : ObservableCollection<AccountItem>{
        public string Key { get; set; }
    }
}
