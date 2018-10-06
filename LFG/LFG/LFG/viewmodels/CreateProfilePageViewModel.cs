using System;
using System.Windows.Input;
using LFG.models;
using Xamarin.Forms;
using PCLStorage;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace LFG.viewmodels
{
    [DataContract]
    public class CreateProfilePageViewModel : ViewModelBase {

        [DataMember]
        public Profile PlayerProfile;
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

        public async Task PCLSPlayerProfile<T>(T PlayerProfile) {
            var ms = new MemoryStream();
            var js = new DataContractJsonSerializer(typeof(T));
            js.WriteObject(ms, PlayerProfile);
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("MyProfile", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("MyPlayerProfile" + ".json", CreationCollisionOption.ReplaceExisting);
            StreamReader sr = new StreamReader(ms);
            await file.WriteAllTextAsync(sr.ReadToEnd());
        }
    }
}
