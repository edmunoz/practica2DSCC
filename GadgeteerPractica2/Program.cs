using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;

namespace GadgeteerPractica2
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            /*******************************************************************************************
            Modules added in the Program.gadgeteer designer view are used by typing 
            their name followed by a period, e.g.  button.  or  camera.
            
            Many modules generate useful events. Type +=<tab><tab> to add a handler to an event, e.g.:
                button.ButtonPressed +=<tab><tab>
            
            If you want to do something periodically, use a GT.Timer and handle its Tick event, e.g.:
                GT.Timer timer = new GT.Timer(1000); // every second (1000ms)
                timer.Tick +=<tab><tab>
                timer.Start();
            *******************************************************************************************/
     
        
            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            //Thread.Sleep(2000);
            
            Debug.Print("Program Started");
            camera.BitmapStreamed += camera_BitmapStreamed;
            camera.CameraConnected += camera_CameraConnected;
            //camera.StartStreaming();
            //this.button.ButtonPressed += button_ButtonPressed;  
           
        }

        void camera_CameraConnected(Camera sender, EventArgs e)
        {
            Debug.Print("CameraConnected");
            camera.StartStreaming();
        }

        void button_ButtonPressed(Button sender, Button.ButtonState state)
        {
            //this.camera.StartStreaming();
        }

        void camera_BitmapStreamed(Camera sender, Bitmap e)
        {           
            displayT35.SimpleGraphics.DisplayImage(e,0,0);
            //this.camera.StopStreaming();
        }
    }
}
