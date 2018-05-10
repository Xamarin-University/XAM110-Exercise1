using Android.App;
using Android.OS;
using System.Linq;

namespace MyTunes
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		protected async override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
            /*
			ListAdapter = new ListAdapter<string>() {
				DataSource = new[] { "One", "Two", "Three" }
			};
            */

           var data= await SongLoader.Load();

            /*
             * you can't do ListAdapter.DataSource because ListAdapter is of type IListAdapter and not ListAdapter, so it can't access the properties of the subclass
             */

            ListAdapter = new ListAdapter<Song>()
            {
                DataSource = data.ToList(),

                // you are saying that whatever it gets as parameter, return the property Name (as it knows that is a Song object when you created the ListAdapter<Song>
                TextProc = s => s.Name,
                DetailTextProc = s => s.Artist + " - " + s.Album
            };



        }
	}
}


