function onSourceDownloadProgressChanged(sender, eventArgs) {
 var progress = Math.round(eventArgs.progress * 100);
 sender.findName("uxStatus").Text = progress.toString();
// if (progress >= 95) {
//  sender.findName("LayoutRoot").Opacity = 0.2;
//  sender.findName("Message").Opacity = 1;
// }
}
function onSourceDownloadComplete(sender, eventArgs) {
 sender.findName("uxStatus").Text = "100";
}
