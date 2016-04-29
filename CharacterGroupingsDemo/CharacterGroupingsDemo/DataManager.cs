using CharacterGroupingsDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.Collation;

namespace CharacterGroupingsDemo {
    public class DataManager {
        public static ObservableCollection<AccountItem> DataList { get; set; } = new ObservableCollection<AccountItem> {
            new AccountItem { Name="Tom", Score = 10 },
            new AccountItem { Name="Help", Score = 11 },
            new AccountItem { Name="Eric", Score = 3 },
            new AccountItem { Name="Emma", Score = 4 },
            new AccountItem { Name="Jack", Score = 8 },
            new AccountItem { Name="Coco", Score = 14 },
            new AccountItem { Name="Joe", Score = 2 },
            new AccountItem { Name="Eva", Score = 8 },
            new AccountItem { Name="May", Score = 9 },
            new AccountItem { Name="Cindy", Score = 4 },
            new AccountItem { Name="Wei", Score = 14 },
            new AccountItem { Name="店小二", Score = 11 },
            new AccountItem { Name="老王", Score = 2 },
            new AccountItem { Name="小張", Score = 3 },
            new AccountItem { Name="一支菸", Score = 3 },
            new AccountItem { Name="老夫子", Score = 7 },
            new AccountItem { Name="番薯", Score = 7 },
            new AccountItem { Name="地瓜", Score = 2 },
            new AccountItem { Name="甜不辣", Score = 17 },
        };

        public ObservableCollection<AlphaKeyContent> AlphaGroups { get; set; }

        public DataManager() {
            AlphaGroups = new ObservableCollection<AlphaKeyContent>();
            CharacterGroupings cg = new CharacterGroupings();
            
            foreach (var key in cg) {
                if (!string.IsNullOrEmpty(key.Label)) {
                    AlphaGroups.Add(new AlphaKeyContent { Key = key.Label });
                }
            }
            var list = from f in DataList
                       group f by cg.Lookup(f.Name) into g
                       orderby g.Key
                       select g;
            foreach (var group in list) {
                var collection = AlphaGroups.FirstOrDefault(f => group.Key.Equals(f.Key));
                if (collection == null) collection = AlphaGroups.Last();
                foreach (var item in group) {
                    collection.Add(item);
                }
            }
        }
    }
}