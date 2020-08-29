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
        public Task<List<Weeklijst>> GetItemsAsync()
        {
            return Database.Table<Weeklijst>().ToListAsync();
        }

        public Task<List<Weeklijst>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Weeklijst>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Weeklijst> GetItemAsync(int id)
        {
            return Database.Table<Weeklijst>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Weeklijst item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Weeklijst item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
