using EGA_Lijst.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Voeding).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Voeding)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }
        public Task<List<Weeklijst>> GetWeeklijstAsync(DateTime dt)
        {
            return Database.Table<Weeklijst>().Where(w=>w.StartDatum==dt.Date).ToListAsync();
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
            return Database.Table<Voeding>().Where(v=>v.WeekLijstId==weekLijstId).OrderBy(v=>v.NaamVoeding).ToListAsync();
        }
        public void UpdateVoedingLijst(ObservableCollection<Voeding> voedingLijst)
        {
            foreach (Voeding v in voedingLijst)
            {
                var x = SaveVoedingAsync(v);
            }
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
        public Task<int> FillNewWeek(int weekLijstId)
        {
            System.Threading.Tasks.Task<int> result;
            Voeding Lever = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Lever",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Lever);

            Voeding Vlees1 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vlees",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Vlees1);
            Voeding Vlees2 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vlees",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Vlees2);
            Voeding Vlees3 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vlees",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Vlees3);
            Voeding Vis1 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Vis1);
            Voeding Vis2 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Vis2);
            Voeding Vis3 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Vis3);
            Voeding Vis4 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Vis4);
            Voeding Vis5 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Vis5);
            Voeding Kaas1 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kaas1);
            Voeding Kaas2 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kaas2);
            Voeding Kaas3 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kaas3);
            Voeding Kaas4 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Vis",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kaas4);
            Voeding Ei1 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Ei",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Ei1);
            Voeding Ei2 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Ei",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Ei2);
            Voeding Ei3 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Ei",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Ei3);
            Voeding Ei4= new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Ei",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Ei4);
            Voeding Kip1 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip1);
            Voeding Kip2 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip2);
            Voeding Kip3 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip3);
            Voeding Kip4 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip4);
            Voeding Kip5 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip5);
            Voeding Kip6 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip6);
            Voeding Kip7 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip7);
            Voeding Kip8 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip8);
            Voeding Kip9 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip9);
            Voeding Kip10 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip10);
            Voeding Kip11 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip11);
            Voeding Kip12 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip12);
            Voeding Kip13 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip13);
            Voeding Kip14 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Kip",
                IsVerplichteVoeding = false,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Kip14);
            Voeding Groenten1 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Groenten1);
            Voeding Groenten2 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Groenten2);
            Voeding Groenten3 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Groenten3);
            Voeding Groenten4 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Groenten4);
            Voeding Groenten5 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Groenten5);
            Voeding Groenten6 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Groenten6);
            Voeding Groenten7 = new Voeding
            {
                WeekLijstId = weekLijstId,
                NaamVoeding = "Verplichte groenten",
                IsVerplichteVoeding = true,
                IsGenuttigd = false
            };
            result = Database.InsertAsync(Groenten7);
            return result;
        }
    }

}
