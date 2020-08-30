using EGA_Lijst.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGA_Lijst
{
    public class WeeklijstDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public WeeklijstDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Weeklijst).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Weeklijst)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }
        public Task<List<Weeklijst>> GetWeeklijstAsync()
        {
            return Database.Table<Weeklijst>().ToListAsync();
        }

        public Task<List<Weeklijst>> GetWeeklijstNotDoneAsync()
        {
            return Database.QueryAsync<Weeklijst>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Weeklijst> GetWeeklijstAsync(int id)
        {
            return Database.Table<Weeklijst>().Where(i => i.WeekLijstId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveWeeklijstAsync(Weeklijst item)
        {
            if (item.WeekLijstId != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteWeeklijstAsync(Weeklijst item)
        {
            return Database.DeleteAsync(item);
        }

        public Task<int> AddNewWeek(DateTime date)
        {
            //add week
            Weeklijst weeklijst = new Weeklijst();
            weeklijst.StartDatum = date;
            return Database.InsertAsync(weeklijst);
        }

        public Task<List<Voeding>> GetVoedingAsync(int weekLijstId)
        {
            return Database.Table<Voeding>().Where(v=>v.WeekLijstId==weekLijstId).ToListAsync();
        }

        public Task<int> SaveVoedingAsync(Voeding item)
        {
            if (item.VoedingId != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteVoedingAsync(Voeding item)
        {
            return Database.DeleteAsync(item);
        }


        //Fill new week
        public void FillNewWeek(int weekLijstId)
        {
            Voeding Lever = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Lever",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Lever);

            Voeding Vlees1 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vlees",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Vlees1);
            Voeding Vlees2 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vlees",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Vlees2);
            Voeding Vlees3 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vlees",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Vlees3);
            Voeding Vis1 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Vis1);
            Voeding Vis2 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Vis2);
            Voeding Vis3 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Vis3);
            Voeding Vis4 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Vis4);
            Voeding Vis5 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Vis5);
            Voeding Kaas1 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kaas1);
            Voeding Kaas2 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kaas2);
            Voeding Kaas3 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kaas3);
            Voeding Kaas4 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kaas4);
            Voeding Ei1 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Ei",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Ei1);
            Voeding Ei2 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Ei",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Ei2);
            Voeding Ei3 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Ei",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Ei3);
            Voeding Ei4= new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Ei",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Ei4);
            Voeding Kip1 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };             
            SaveVoedingAsync(Kip1);
            Voeding Kip2 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kip2);
            Voeding Kip3 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kip3);
            Voeding Kip4 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kip4);
            Voeding Kip5 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kip5);
            Voeding Kip6 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kip6);
            Voeding Kip7 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kip7);
            Voeding Kip8 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kip8);
            Voeding Kip9 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kip9);
            Voeding Kip10 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kip10);
            Voeding Kip11 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kip11);
            Voeding Kip12 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kip12);
            Voeding Kip13 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kip13);
            Voeding Kip14 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Kip14);
            Voeding Groenten1 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Groenten1);
            Voeding Groenten2 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Groenten2);
            Voeding Groenten3 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Groenten3);
            Voeding Groenten4 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Groenten4);
            Voeding Groenten5 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Groenten5);
            Voeding Groenten6 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Groenten6);
            Voeding Groenten7 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            SaveVoedingAsync(Groenten7);
        }
    }

}
