using System;
using System.Windows.Input;
using LFG.models;
using Xamarin.Forms;
using PCLStorage;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Text;

namespace LFG.viewmodels
{
    [DataContract]
    public class CreateProfilePageViewModel : ViewModelBase {


        [DataMember]
        public Profile PlayerProfile;
        public Profile DeserializedPlayerProfile;
        public ICommand SaveCommand { get; private set; }

        public CreateProfilePageViewModel() {
            PlayerProfile = new Profile();
            SaveCommand = new Command(async () => await SaveAsync());
        }


        //TODO function to save PlayerProfile
        public async Task SaveAsync() {
            await PCLSPlayerProfile(PlayerProfile);
            Console.WriteLine("Saved!");
        }

        public async Task PCLSPlayerProfile<Profile>(Profile playerProfile) {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Profile));
            js.WriteObject(ms, playerProfile);
            byte[] json = ms.ToArray();
            ms.Close();

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("MyProfile", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("MyPlayerProfile" + ".json", CreationCollisionOption.ReplaceExisting);

            StreamReader sr = new StreamReader(ms);
            await file.WriteAllTextAsync(sr.ReadToEnd());
        }

        public async Task PCLDSPlayerProfile<Profile>(Profile outputPlayerProfile) where Profile : class {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("MyProfile", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("MyPlayerProfile" + ".json", CreationCollisionOption.OpenIfExists);

            string jsonString = await file.ReadAllTextAsync();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Profile));
            outputPlayerProfile = js.ReadObject(ms) as Profile;
            ms.Close();
        }
    }
}
