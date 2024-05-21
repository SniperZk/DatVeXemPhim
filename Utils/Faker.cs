using System;
using System.Collections.Generic;
using System.Linq;

namespace DatVeXemPhim.Utils
{
    public struct WordGroup
    {
        public string[] Subjects;
        public string[] Locations;
        public string[] Concepts;
        public string[] Verbs1;
        public string[] Verbs2;
        public string[] Adjectives;
        public string[] Nouns
        {
            get
            {
                return Subjects.Union(Locations).Union(Concepts).ToArray();
            }
        }
        public string[] Verbs
        {
            get
            {
                return Verbs1.Union(Verbs2).ToArray();
            }
        }

        public WordGroup()
        {
            Subjects = [];
            Locations = [];
            Concepts = [];
            Verbs1 = [];
            Verbs2 = [];
            Adjectives = [];
        }
    }

    public class Faker
    {
        private Random rand;

        public static readonly string[] RATINGS = { "P", "K", "T13", "T16", "T18" };
        public static readonly string[] CATEGORIES = { "Hành động", "Tâm lý", "Kinh dị", "Lãng mạn", "Kỳ ảo" };
        public static readonly Dictionary<string, WordGroup> CAT_WORDS = initCategoryWords();
        public static readonly WordGroup COMMON_WORDS = new WordGroup
        {
            Subjects = ["lập trình viên", "công nhân", "bác sĩ", "cô giáo", "thầy giáo"],
            Locations = ["căn phòng", "ngôi nhà", "ngôi làng"],
            Concepts = ["bài học", "điện thoại"],
            Verbs1 = ["giúp đỡ"],
            Verbs2 = ["đi ngủ", "đón Tết"],
            Adjectives = ["bình thường", "tầm thường"],
        };

        public Faker()
        {
            rand = new Random();
        }
        public Faker(int seed)
        {
            rand = new Random(seed);
        }

        public static Dictionary<string, WordGroup> initCategoryWords()
        {
            Dictionary<string, WordGroup> words = new Dictionary<string, WordGroup>()
            {
                {
                    "Hành động", new WordGroup {
                        Subjects = ["điệp viên", "băng cướp", "giang hồ", "thám tử", "hiệp sĩ", "kế hoạch", "kẻ lừa đảo", "người nhện", "người sói", "người sắt", "người kiến", "quái nhân", "siêu nhân", "tội phạm", "thợ săn", "sát thủ", "siêu trộm", "cảnh sát", "đặc cảnh"],
                        Locations = ["sòng bạc", "chiến trường", "võ đài", "đường hầm", "thành phố", "thị trấn", "vương quốc"],
                        Concepts = ["hành trình", "cuộc chiến", "đại chiến", "nhiệm vụ", "phi vụ", "kế hoạch"],
                        Verbs1 = ["tiêu diệt", "giải cứu", "truy lùng", "truy sát", "huỷ diệt", "đối đầu"],
                        Verbs2 = ["báo thù", "giải hận", "bị sát hại", "đào tẩu", "vượt ngục", "trở về nhà", "phá bom", "di cư", "hành động"],
                        Adjectives = ["kinh hoàng", "siêu bạo chúa", "bất hảo", "vĩ đại", "nguy hiểm", "bóng đêm", "lừng danh", "khét tiếng", "bá vương", "vô hình", "ngầm"],
                    }
                },
                {
                    "Tâm lý", new WordGroup {
                        Subjects = ["linh hồn", "người lắng nghe", "người tù", "rồng xanh", "chúng tôi", "cu li", "gia đình", "thiên thần", "cô dâu", "cô gái", "đứa con"],
                        Locations = ["đường hầm", "thành phố", "thị trấn", "ngôi nhà", "khu rừng", "ngôi trường", "cánh đồng"],
                        Concepts = ["sự thật", "định kiến", "ảo ảnh", "cuộc chiến", "sức mạnh", "mùa hè", "ký ức"],
                        Verbs1 = ["thoát khỏi", "vạch trần", "tìm ra", "cưới"],
                        Verbs2 = ["tự sát", "trở về nhà", "trốn thoát", "không bao giờ khóc", "giải hạn"],
                        Adjectives = ["đau khổ", "rực rỡ", "vĩ đại", "cuối cùng", "đầu tiên", "trong bóng tối", "khổ sai", "diệu kỳ", "bình yên", "trắng", "bất tận"],
                    }
                },
                {
                    "Kinh dị", new WordGroup {
                        Subjects = ["tử thi", "cá sấu", "kẻ rình mò", "tử thần", "cá mập", "ma", "hung thần", "quỷ", "quái vật", "búp bê", "phù thuỷ", "ác thần", "ma cà rồng", "rắn đuôi chuông", "oan hồn", "hài cốt", "thây ma", "xác ướp", "người sói", "mãng xà", "vong hồn"],
                        Locations = ["khách sạn", "thành phố", "thị trấn", "vương quốc", "khu rừng", "đáy hồ", "căn phòng", "nghĩa địa", "địa ngục", "mê cung", "căn hầm"],
                        Concepts = ["lời nguyền", "ác mộng", "tội ác", "nghi lễ", "tiếng hét"],
                        Verbs1 = ["ăn thịt", "thôi miên", "nguyền rủa"],
                        Verbs2 = ["tự sát", "trôi dạt", "sinh tồn", "tìm xác", "nhập hồn", "trở về", "trỗi dậy", "đói khát", "tế thần", "siêu thoát"],
                        Adjectives = ["máu", "đại dương", "khổng lồ", "tăm tối", "sương mù", "kinh hoàng", "quái dị", "đẫm máu", "lúc nửa đêm", "ám ảnh", "câm lặng", "điên dại", "chết chóc"],
                    }
                },
                {
                    "Lãng mạn", new WordGroup {
                        Subjects = ["cô gái", "công chúa", "hoàng tử", "phu nhân", "người vợ", "người chồng", "anh chàng", "chúng ta", "nàng thơ", "nhà văn", "thi sĩ", "cô dâu", "chú rể", "thiếu nữ", "tiểu thư"],
                        Locations = ["khách sạn", "thành phố", "thị trấn", "vương quốc", "ngọn đồi", "vườn hoa", "bờ biển"],
                        Concepts = ["lần hẹn", "trái tim", "tuổi trẻ", "hồi ức", "tình ca", "mối tình đầu", "bí mật", "vũ điệu", "tâm hồn", "cuộc gặp gỡ", "đám cưới", "ánh trăng", "nụ hôn"],
                        Verbs1 = ["phải lòng", "yêu", "ghét", "thương nhớ", "chờ đợi"],
                        Verbs2 = ["ngoại tình", "biết yêu", "rơi vào lưới tình", "lạc lối", "rơi lệ"],
                        Adjectives = ["đầu tiên", "thanh xuân", "màu tím", "bất tận", "rực lửa", "mộng mơ", "hoang dã", "định mệnh", "lãng mạn", "đáng yêu", "văn chương", "màu hồng"],
                    }
                },
                {
                    "Kỳ ảo", new WordGroup {
                        Subjects = ["rồng", "pháp sư", "phù thuỷ", "tinh linh", "chúa quỷ", "vị thần", "chúa tể", "chiến binh", "thần chết", "sinh vật", "phong thần", "ảo thuật gia", "người cá", "khỉ đột", "giáo sĩ", "hầu vương", "gấu đỏ"],
                        Locations = ["xứ sở", "thành phố", "hành tinh", "vương quốc", "ngục tối", "con đường", "lâu đài", "đấu trường", "thế giới"],
                        Concepts = ["câu chuyện", "huyền thoại", "thần thoại", "bí mật", "giấc mơ", "cuộc đổ bộ", "cánh cổng", "ảo ảnh", "ánh sao", "chiếc đũa", "cây sáo"],
                        Verbs1 = ["biến thành", "hẹn gặp", "đi tìm"],
                        Verbs2 = ["giao hàng", "bị lạc", "mất tích", "biến hình", "luyện rồng"],
                        Adjectives = ["thần bí", "phép thuật", "trên không", "thần tiên", "thời tiền sử", "bí ẩn", "huyền bí", "khổng lồ", "ngoài hành tinh", "ảo", "xanh", "biết nói", "quyền năng", "siêu nhiên"],
                    }
                },
            };
            return words;
        }

        public int randInt(int max)
        {
            return rand.Next(max);
        }
        public T randChoice<T>(IReadOnlyList<T> list)
        {
            return list[rand.Next(list.Count)];
        }
        public T randChoice<T>(IReadOnlyList<T> list, T lastChoice) where T : IComparable
        {
            T choice = list[rand.Next(list.Count)];
            while (choice.CompareTo(lastChoice) == 0)
            {
                choice = list[rand.Next(list.Count)];
            }
            return choice;
        }

        public string randomTitle(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                category = randomCategory();
            }
            if (CAT_WORDS.ContainsKey(category))
            {
                WordGroup words = CAT_WORDS[category];
                WordGroup allWords = COMMON_WORDS;
                foreach (var item in CAT_WORDS)
                {
                    WordGroup currWords = item.Value;
                    if (item.Key != category)
                    {
                        allWords.Verbs1 = allWords.Verbs1.Union(currWords.Verbs1).ToArray();
                        allWords.Verbs2 = allWords.Verbs2.Union(currWords.Verbs2).ToArray();
                        allWords.Subjects = allWords.Subjects.Union(currWords.Subjects).ToArray();
                        allWords.Locations = allWords.Locations.Union(currWords.Locations).ToArray();
                        allWords.Adjectives = allWords.Adjectives.Union(currWords.Adjectives).ToArray();
                    }
                }
                string title = "";
                switch (rand.Next(15))
                {
                    case 0:
                        {
                            title = $"{randChoice(words.Subjects)} {randChoice(words.Verbs)}";
                            break;
                        }
                    case 1:
                        {
                            title = $"{randChoice(words.Nouns)} {randChoice(words.Adjectives)}";
                            break;
                        }
                    case 2:
                        {
                            title = $"{randChoice(words.Subjects)} {randChoice(words.Adjectives)} {randChoice(words.Verbs2)}";
                            break;
                        }
                    case 3:
                        {
                            title = $"{randChoice(words.Subjects)} {randChoice(words.Verbs1)} {randChoice(words.Subjects)}";
                            break;
                        }
                    case 4:
                        {
                            title = $"{rand.Next(3, 101)} ngày {randChoice(words.Verbs)}";
                            break;
                        }
                    case 5:
                        {
                            title = $"{rand.Next(1, 11)} năm {randChoice(words.Verbs)}";
                            break;
                        }
                    case 6:
                        {
                            title = $"{randChoice(words.Nouns)} số {rand.Next(10, 101)}";
                            break;
                        }
                    case 7:
                        {
                            title = $"{randChoice(words.Nouns)}, {randChoice(words.Nouns)} và {randChoice(allWords.Nouns)}";
                            break;
                        }
                    case 8:
                        {
                            title = $"{randChoice(words.Verbs)} ở {randChoice(words.Locations)} {randChoice(words.Adjectives)}";
                            break;
                        }
                    case 9:
                        {
                            title = $"{randChoice(words.Locations)} {randChoice(words.Subjects)}";
                            break;
                        }
                    case 10:
                        {
                            title = $"{randChoice(words.Locations)} {randChoice(words.Concepts)}";
                            break;
                        }
                    case 11:
                        {
                            title = $"{randChoice(allWords.Nouns)} {randChoice(words.Adjectives)} và {randChoice(words.Nouns)} {randChoice(allWords.Adjectives)}";
                            break;
                        }
                    case 12:
                        {
                            title = $"{randChoice(words.Nouns)} {randChoice(words.Adjectives)} và {randChoice(allWords.Nouns)} {randChoice(allWords.Adjectives)}";
                            break;
                        }
                    case 13:
                        {
                            title = $"{rand.Next(3, 51)} lần {randChoice(allWords.Verbs)}";
                            break;
                        }
                    case 14:
                        {
                            title = $"{randChoice(words.Subjects)} {randChoice(allWords.Verbs2)}, {randChoice(words.Subjects)} {randChoice(allWords.Verbs2)}";
                            break;
                        }
                    default:
                        break;
                }
                title = title[0].ToString().ToUpper() + title.Substring(1);
                if (rand.Next(100) == 0)
                {
                    title += " II";
                }
                return title;

            }
            else
            {
                throw new ArgumentException("Invalid category", category);
            }
        }

        public DateTime randomDate()
        {
            DateTime start = DateTime.Today - TimeSpan.FromDays(14);
            return start.AddDays(rand.Next(14));
        }
        public TimeSpan randomDuration()
        {
            return new TimeSpan(rand.Next(0, 3), rand.Next(0, 60), 0);
        }
        public string randomCategory()
        {
            return randChoice(CATEGORIES);
        }
        public string randomRating()
        {
            return randChoice(RATINGS);
        }
    }
}
