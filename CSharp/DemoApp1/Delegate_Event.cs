delegate void PaymentDelegate(decimal amount);
class PaymentService
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Payment of "+amount+" processed successfuly");
    }
    public void RTGS(decimal amount)
    {
        Console.WriteLine("Payment of "+amount+" processed by RTGS successfuly");
    }
}
static class PaymentExtension
{
    public static bool IsValidPayment(this decimal amount)
    {
        return amount>0&&amount<=1_00_000;
    }
}


class Button
{
    public delegate void ClickHandler();
    public event ClickHandler Clicked;
    public void Click()
    {
        Clicked?.Invoke();
    }
}

namespace SmartHomeSecurity
{
    // 1. DEFINITION: The "Contract" for any security response.
    // Any method responding to an alert must be void and take a string location.

    public delegate void SecurityAction(string zone); // definition

    public class MotionSensor
    {
        // The delegate instance (The Panic Button)
        public SecurityAction OnEmergency; // instance creation

        public void DetectIntruder(string zoneName)
        {
            Console.WriteLine($"[SENSOR] Motion detected in {zoneName}!");
            
            // 3. INVOCATION: Triggering the Panic Button
            // if (OnEmergency != null)
            // {
            //     OnEmergency(zoneName); // string value = Main Lobby or panicSequence?
            // }
            OnEmergency?.Invoke(zoneName);
        }
    }

    // Diverse classes that don't know about each other
    public class AlarmSystem
    {
        public void SoundSiren(string zone) => Console.WriteLine($"[ALARM] WOO-OOO! High-decibel siren active in {zone}.");
    }

    public class PoliceNotifier
    {
        public void CallDispatch(string zone) => Console.WriteLine($"[POLICE] Notifying local precinct of intrusion in {zone}.");
    }

    class Program
    {
        public static void main()
        {
            // Objects Initialization
            MotionSensor livingRoomSensor = new MotionSensor();
            AlarmSystem siren = new AlarmSystem();
            PoliceNotifier police = new PoliceNotifier();

            // 2. INSTANTIATION & MULTICASTING
            // We "Subscribe" different methods to the sensor's delegate
            SecurityAction panicSequence = siren.SoundSiren; // Assignment of methods
            panicSequence += police.CallDispatch;

            // Linking the sequence to the sensor
            livingRoomSensor.OnEmergency = panicSequence;
	        // class_object.delegate_instance = delegate_instance_multicast

            // Simulation
            livingRoomSensor.DetectIntruder("Main Lobby");
        }
    }
}


namespace CallbackDemo
{
    // STEP 1: Define the Delegate
    public delegate void DownloadFinishedHandler(string fileName);

    class FileDownloader
    {
        // STEP 2: Method that accepts the callback
        public void DownloadFile(string name, DownloadFinishedHandler callback)
        {
            Console.WriteLine($"Starting download: {name}...");
            
            // Simulating work
            Thread.Sleep(2000); 
            
            Console.WriteLine($"{name} download complete.");

            // STEP 3: Execute the Callback
            if (callback != null)
            {
                callback(name); 
            }
        }
    }

    class Program
    {
        // STEP 4: The actual Callback Method
        static void DisplayNotification(string file)
        {
            Console.WriteLine($"NOTIFICATION: You can now open {file}.");
        }

        // static void Main()
        // {
        //     FileDownloader downloader = new FileDownloader();

        //     // Pass the method 'DisplayNotification' as a callback
        //     downloader.DownloadFile("Presentation.pdf", DisplayNotification);
        // }
    }
}