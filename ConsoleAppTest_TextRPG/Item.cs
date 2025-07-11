namespace ConsoleAppTest_TextRPG
{
    // 아이템을 관리하는 클래스
    public class Item
    {
        #region Fields
        private string name;
        private int type;
        private int attackPlus;
        private int defensePlus;
        private int hpPlus;
        private int rank;
        private int price;
        private string description;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public int AttackPlus
        {
            get { return attackPlus; }
            set { attackPlus = value; }
        }
        public int DefensePlus
        {
            get { return defensePlus; }
            set { defensePlus = value; }
        }
        public int HpPlus
        {
            get { return hpPlus; }
            set { hpPlus = value; }
        }
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        #endregion

    }

    // 아이템 정보를 csv파일을 통해 불러오는 클래스
    public class ItemLoader
    {
        public static List<Item> LoadItems(string fileName)
        {
            var items = new List<Item>();
            using (var reader = new StreamReader(fileName))
            {
                string line;
                bool isFirst = true;
                while ((line = reader.ReadLine()) != null)
                {
                    if (isFirst) { isFirst = false; continue; } // 헤더 건너뜀
                    var fields = line.Split(',');
                    var item = new Item
                    {
                        Name = fields[0],
                        Type = int.Parse(fields[1]),
                        Price = int.Parse(fields[2]),
                        Description = fields[3],
                        AttackPlus = int.Parse(fields[4]),
                        DefensePlus = int.Parse(fields[5]),
                        HpPlus = int.Parse(fields[6]),
                        Rank = int.Parse(fields[7])
                    };
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
