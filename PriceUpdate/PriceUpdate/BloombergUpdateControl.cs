using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriceUpdateProgram;
using System.Timers;

namespace PriceUpdate
{
    public partial class BloombergUpdateControl : UserControl
    {
        delegate void SetRandomCallback(string text);
        List<string> messages = new List<string>
        #region Messages
        { "Reticulating Splines","Gathering Goblins","Lifting Weights","Pushing Pixels","Formulating Plan","Taking Break",
"Herding Ducks","Feeding Developers","Fishing for Change","Searching for Dancers","Waking Up Gnomes","Playing Chess","Building Igloos","Converting Celsius",
"Scanning Power Level","Delivering Presents","Finding Dragon Balls","Firing Lasers","Party Rocking","Walking up to the club","Righting wrongs","Building Lego",
"Assembling Avengers","Turning Down for What","Reaching 88mph","Pondering Existence","Battling Robots","Smashing Pots","Stomping Goombas","Doing Donuts","Entering Danger Zone",
"Talking to Mom","Chasing Squirrels","Setting Phasers to Stun","Doing Macarena","Dropping Bass","Removing Biebers","Performing Magic","Autotuning Kanye","Waxing Legs",
"Invading Space","Levelling Up","Generating Map","Conquering France","Piloting Tardis","Destroying Deathstar","Typing Letters","Making Code","Running Marathon","Shooting Pucks",
"Kicking Field Goals","Fighting Bad Guys","Driving Batmobile","Warming Up Kryptonite","Popping Popcorn","Creating Hashes","Spawning Boss","Evaluating Life Choices","Eating Ramen",
"Re-heating Leftovers","Petting Kittens","Walking Puppies","Catching Z’s","Jumping Rope","Declaring Variables","Yessing Doge","Recycling Memes",
"Tipping Fedora","Walking Runway","Counting to Ten","Booting Native Client","Launching App","Drawing Icons","Reading Instructions","Finding Screws","Completing Puzzles",
"Generating Volume Slider","Brightening Orange","Ordering Pizza","You Look Good Today","Clearing Screen","Stirring Pot","Mashing Potatoes","Banishing Evil","Taking Selfies",
"Accelerating Disks","Benching Network","Rocking Out","Grinding Mage","Studying Calculus","Playing N64","Racing GoKarts","Defeating Creepers","Blowing Game Cartridge",
"Choosing Pikachu","Postponing Half Life 3","Rushing Zergs","Rescuing Hostages","Typing Konami Code","Building Snowman","Letting it Snow","Burning HDMI Cords",
"Applying Filters","Taking Screenshot","Shaving Mustache","Growing Beard","Baking Muffins","Iterating Javascript","Attracting Venture Capital","Disrupting Industry",
"Tweeting Hashtags","Encrypting Lines","Obfuscating C","Enhancing License Plate","Running Diagnostic","Warming Hyperdrive","Calibrating Positions","Calculating Percentages",
"Revoking Licenses","Shedding Core","Dampening Gravity","Increasing Power","Checking Sensors","Indexing RSS","Programming PCI","Determining USB Position","Connecting to Bus",
"Inverting Ports","Bypassing Capacitor","Reversing Bandwidth Throttle","Testing AI","Virtualizing Microchip","Emulating Playstation","Synthesizing Drivers","Structuring Chlorophyll",
"Watering Plants","Ingesting Caffeine","Chugging Redbull","Parsing System","Navigating Arrays","Searching Google","Overflowing Stack","Compiling Binaries","Answering Emails",
"Migrating CSS","Backing Up Primaries","Rendering Dialogs","Reading RSS","Compressing Data","Rejecting Cloud","Evaluating Weissman Score","Purging Local Storage","Leaking Memory",
"Scripting Python","Grunting Ruby","Benching RAM","Determining Auxiliaries","Jiggling Internet","Ejecting Floppy","Fluctuating Objects","Spiking Reactor Core","Firing Bosons",
"Testing Processor","Debugging Prompts","Connecting Floats","Rounding Integers","Pronouncing Gigawatt","Inverting Transponders","Bypassing Silicon","Raising Funds","Caching Logs",
"Dithering Broadband","Eating Poutine","Rolling Rims to Win","Begging for Change","Chasing Waterfalls","Pumping Gas","Emptying Pipes","Hitting Piñata","Unleashing Freedom",
"Airbrushing Actors","FIling Taxes","Powering Mitochondria","Calculating Qi charge","Completing Geometry","Turning in Algebra","Solving for X","Benching Wattage",
"Kludging Playback Bar","Stringifying Json","Consuming Spaghetti Code","Deleting Comments","Transitioning to Django","Learning to Code","Battling Feature Creep",
"Losing Flappy Bird","Celebrating Good Times","Sharpening Pencils","Automating Processes","Attacking Godzilla","Carbonating Soda","Thinking of Witty Text"};
        #endregion
        public BloombergUpdateControl()
        {
            InitializeComponent();
            Random rnd = new Random();
            circleProgressBar.Num.Font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);
            circleProgressBar.Unit.Font = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel);
            circleProgressBar.Value = 0;
            var aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Interval = 3000;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (circleProgressBar.Value != 100)
            SetRandomText(getRandomText());
        }
        private void SetRandomText(string text)
        {
            if (this.randomLabel.InvokeRequired)
            {
                SetRandomCallback d = new SetRandomCallback(SetRandomText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.randomLabel.Text = text;
            }
        }
        private string getRandomText()
        {
            Random r = new Random();
            int index = r.Next(messages.Count);
            return messages[index];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BloombergHelper bh = new BloombergHelper();
            bh.Run();
            //circleProgressBar.Value = bh.Percentage;
            if(circleProgressBar.Value < 90)
            circleProgressBar.Value = circleProgressBar.Value + 10;
            else
            {
                circleProgressBar.Value = 100;
                circleProgressBar.ForeColor = Color.Green;
            }
        }
    }
}
