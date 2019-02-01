namespace HelloFabulous.Android

open System
open System.Threading.Tasks
open Com.Microsoft.Azure.Storage

module StorageService =

    let saveImage key s =
        async {
            let account = CloudStorageAccount.Parse(key)
            let blobClient = account.CreateCloudBlobClient()
            let container = blobClient.GetContainerReference("photos")
            let blob = container.GetBlockBlobReference(Guid.NewGuid().ToString("N") + ".jpg")
            do! Task.Run(fun () -> blob.Upload(s, s.Length)) |> Async.AwaitTask
        }

