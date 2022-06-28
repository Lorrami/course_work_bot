using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Bot
{
    public class Bot
    {
        private readonly TelegramBotClient _botClient = new TelegramBotClient("5471368494:AAFHorXOOKxA5R4mBu220nCDT5otlXTrXd8");
        private readonly CancellationToken _cancellationToken = new CancellationToken();
        private readonly ReceiverOptions _receiverOptions = new ReceiverOptions();
        private string? _specs;
        private List<string> _gamesByGenres = new List<string>();
        private List<string> _genres = new List<string>()
        {
            "MMO",
            "PvP",
            "Adventure",
            "Co-op",
            "Strategy",
            "GDR", "GDR",
            "Single-player",
            "RPG",             
            "Racing",
            "Sports"
        };
        private UserParams _userParams = new UserParams();
        private static bool _continue = false;
        private static bool _isFound = false;
        public async Task Start()
        {
            _botClient.StartReceiving(HandlerUpdateAsync, HandlerError, _receiverOptions, _cancellationToken);
            var botMe = await _botClient.GetMeAsync();
            Console.WriteLine(botMe + "is working!");
            Console.ReadKey();
        }
        private async Task HandlerUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update.Message?.Text != null)
            {
                await HandlerMessageAsync(botClient, update.Message);
                Console.WriteLine(update.Message.Text);
            }
            if (update.Type == UpdateType.CallbackQuery && update.CallbackQuery?.Data != null && !_continue)
            {
                if (update.CallbackQuery.Data == "Weaker")
                {
                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Sorry, your processor is too weak");
                }
                else if (update.CallbackQuery.Data == "Pentium4")
                {
                    _userParams.Processor = "Pentium 4 processor (3.0GHz, or better)";
                }
                else if (update.CallbackQuery.Data == "IntelCore2Duo" || update.CallbackQuery.Data == "AMDPhenomX3")
                {
                    _userParams.Processor = "Intel® Core™ 2 Duo E6600 or AMD Phenom™ X3 8750 processor or better";
                }
                else if (update.CallbackQuery.Data == "IntelCoreI3-530" || update.CallbackQuery.Data == "AMDAthlonIIx3")
                {
                    _userParams.Processor = "Core i3-530 / AMD Athlon II X3 415e";
                }
                else if (update.CallbackQuery.Data == "IntelCoreI53470" || update.CallbackQuery.Data == "AMDAthlon240GE")
                {
                    _userParams.Processor = "Core i5 3470 / AMD Athlon 240GE";
                }
                else if (update.CallbackQuery.Data == "DualCore2orAMD64X2")
                {
                    _userParams.Processor = "3.0 GHz P4, Dual Core 2.0 (or higher) or AMD64X2 (or higher)";
                }
                else if (update.CallbackQuery.Data == "AMDPhenomIIX4940")
                {
                    _userParams.Processor = "Intel CPU Core i5-2500K 3.3GHz / AMD CPU Phenom II X4 940";
                }
                else if (update.CallbackQuery.Data == "IntelCorei737703.4GHz")
                {
                    _userParams.Processor = "Intel CPU Core i7 3770 3.4 GHz / AMD CPU AMD FX-8350 4 GHz";
                }
                else if (update.CallbackQuery.Data == "AMDFX-83504GHz")
                {
                    _userParams.Processor = "Intel CPU Core i7 3770 3.4 GHz / AMD CPU AMD FX-8350 4 GHz";
                }
                else if (update.CallbackQuery.Data == "IntelCorei5-3570K")
                {
                    _userParams.Processor = "Intel Core i5-3570K or AMD FX-8310";
                }
                else if (update.CallbackQuery.Data == "AMDFX-8310")
                {
                    _userParams.Processor = "Intel Core i5-3570K or AMD FX-8310";
                }
                else if (update.CallbackQuery.Data == "IntelCorei7-4790")
                {
                    _userParams.Processor = "Intel Core i7-4790 or AMD Ryzen 3 3200G";
                }
                else if (update.CallbackQuery.Data == "AMDRyzen33200G")
                {
                    _userParams.Processor = "Intel Core i7-4790 or AMD Ryzen 3 3200G";
                }
                else if (update.CallbackQuery.Data == "IntelCorei5orAMDRyzen")
                {
                    _userParams.Processor = "Intel Core i5 or AMD Ryzen";
                }
                else if (update.CallbackQuery.Data == "Intel®Core™i5-2500K")
                {
                    Random rnd = new Random();
                    int n = rnd.Next(0, 2);
                    _userParams.Processor = n == 0 ? "Intel CPU Core i5-2500K 3.3GHz / AMD CPU Phenom II X4 940" : "Intel® Core™ i5-2500K / AMD FX-6300";
                }
                else if (update.CallbackQuery.Data == "AMDFX-6300")
                {
                    _userParams.Processor = "Intel® Core™ i5-2500K / AMD FX-6300";
                }
                else if (update.CallbackQuery.Data == "Intel®Core™i7-4770K")
                {
                    _userParams.Processor = "Intel® Core™ i7-4770K / AMD Ryzen 5 1500X";
                }
                else if (update.CallbackQuery.Data == "AMDRyzen51500X")
                {
                    _userParams.Processor = "Intel® Core™ i7-4770K / AMD Ryzen 5 1500X";
                }
                else if (update.CallbackQuery.Data == "Inteli5-4460")
                {
                    _userParams.Processor = "Intel i5-4460 or AMD Ryzen 3 1200";
                }
                else if (update.CallbackQuery.Data == "AMDRyzen31200")
                {
                    _userParams.Processor = "Intel i5-4460 or AMD Ryzen 3 1200";
                }
                else if (update.CallbackQuery.Data == "Inteli5-8400")
                {
                    _userParams.Processor = "Intel i5-8400 or AMD Ryzen 5 1500X";
                }
                else if (update.CallbackQuery.Data == "AMDRyzen51500X")
                {
                    _userParams.Processor = "Intel i5-8400 or AMD Ryzen 5 1500X";
                }
                else if (update.CallbackQuery.Data == "Intel® Core™ i5-750")
                {
                    _userParams.Processor = "2.6 GHz Intel® Core™ i5-750 or 3.2 GHz AMD Phenom™ II X4 955";
                }
                else if (update.CallbackQuery.Data == "AMD Phenom™ II X4 955")
                {
                    _userParams.Processor = "2.6 GHz Intel® Core™ i5-750 or 3.2 GHz AMD Phenom™ II X4 955";
                }
                else if (update.CallbackQuery.Data == "Intel® Core™ i5-2400S")
                {
                    _userParams.Processor = "2.5 GHz Intel® Core™ i5-2400S or 4.0 GHz AMD FX-8350 or better";
                }
                else if (update.CallbackQuery.Data == "AMD FX-8350")
                {
                    _userParams.Processor = "2.5 GHz Intel® Core™ i5-2400S or 4.0 GHz AMD FX-8350 or better";
                }
                else if (update.CallbackQuery.Data == "Stronger")
                {
                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "I really don't know what are you doing there\n"+
                        "You have a strong computer, so can play in the every game in the world. Bye!");
                }
                else if (update.CallbackQuery.Data == "WeakerGraphics")
                {
                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Sorry, your graphic card is too weak");
                }
                else if (update.CallbackQuery.Data == "Skip")
                {
                    _userParams.Graphics = "Skip";
                }
                else if (update.CallbackQuery.Data == "GeForce 250 GTS")
                {
                    _userParams.Graphics = "GeForce 250 GTS / Radeon HD 4850";
                }
                else if (update.CallbackQuery.Data == "Radeon HD 4850")
                {
                    _userParams.Graphics = "GeForce 250 GTS / Radeon HD 4850";
                }
                else if (update.CallbackQuery.Data == "GeForce 500 Series")
                {
                    _userParams.Graphics = "DirectX 11 compatible Intel HD Graphics 500 Series / AMD Radeon HD 7000 Series / NVIDIA GeForce 500 Series";
                }
                else if (update.CallbackQuery.Data == "Radeon HD 7000 Series")
                {
                    _userParams.Graphics = "DirectX 11 compatible Intel HD Graphics 500 Series / AMD Radeon HD 7000 Series / NVIDIA GeForce 500 Series";
                }
                else if (update.CallbackQuery.Data == "Intel HD Graphics 500 Series")
                {
                    _userParams.Graphics = "DirectX 11 compatible Intel HD Graphics 500 Series / AMD Radeon HD 7000 Series / NVIDIA GeForce 500 Series";
                }
                else if (update.CallbackQuery.Data == "GeForce GTX 460")
                {
                    _userParams.Graphics = "NVIDIA GeForce GTX 460 or AMD Radeon HD5850 (1 GB VRAM)";
                }
                else if (update.CallbackQuery.Data == "Radeon HD5850")
                {
                    _userParams.Graphics = "NVIDIA GeForce GTX 460 or AMD Radeon HD5850 (1 GB VRAM)";
                }
                else if (update.CallbackQuery.Data == "GeForce GTX 660")
                {
                    _userParams.Graphics = "Nvidia GPU GeForce GTX 660 / AMD GPU Radeon HD 7870";
                }
                else if (update.CallbackQuery.Data == "Radeon HD 7870")
                {
                    _userParams.Graphics = "Nvidia GPU GeForce GTX 660 / AMD GPU Radeon HD 7870";
                }
                else if (update.CallbackQuery.Data == "GeForce GTX 680")
                {
                    _userParams.Graphics = "NVIDIA GeForce GTX 680 or AMD Radeon R9 290X or better (2 GB VRAM)";
                }
                else if (update.CallbackQuery.Data == "Radeon R9 290X")
                {
                    _userParams.Graphics = "NVIDIA GeForce GTX 680 or AMD Radeon R9 290X or better (2 GB VRAM)";
                }
                else if (update.CallbackQuery.Data == "GeForce GTX 960")
                {
                    _userParams.Graphics = "DirectX 11 compatible NVIDIA GeForce 960 or higher, AMD R9 280 or higher";
                }
                else if (update.CallbackQuery.Data == "Radeon R9 280")
                {
                    _userParams.Graphics = "DirectX 11 compatible NVIDIA GeForce 960 or higher, AMD R9 280 or higher";
                }
                else if (update.CallbackQuery.Data == "GeForce GTX 770")
                {
                    _userParams.Graphics = "Nvidia GPU GeForce GTX 770 / AMD GPU Radeon R9 290";
                }
                else if (update.CallbackQuery.Data == "Radeon R9 290")
                {
                    _userParams.Graphics = "Nvidia GPU GeForce GTX 770 / AMD GPU Radeon R9 290";
                }
                else if (update.CallbackQuery.Data == "GeForce GTX 970")
                {
                    Random rnd = new Random();
                    int n = rnd.Next(0, 2);
                    _userParams.Graphics = n == 0 ? "NVIDIA GeForce GTX 970 or AMD Radeon RX 470" : "NVidia GTX 970 OR AMD RX 470";
                }
                else if (update.CallbackQuery.Data == "Radeon RX 470")
                {
                    _userParams.Graphics = "NVIDIA GeForce GTX 970 or AMD Radeon RX 470";
                }
                else if (update.CallbackQuery.Data == "GeForce 7600")
                {
                    _userParams.Graphics = "Video card must be 128 MB or more and with support for Pixel Shader 2.0b (ATI Radeon X800 or higher / NVIDIA GeForce 7600 or higher / Intel HD Graphics 2000 or higher).";
                }
                else if (update.CallbackQuery.Data == "Radeon X800")
                {
                    _userParams.Graphics = "Video card must be 128 MB or more and with support for Pixel Shader 2.0b (ATI Radeon X800 or higher / NVIDIA GeForce 7600 or higher / Intel HD Graphics 2000 or higher).";
                }
                else if (update.CallbackQuery.Data == "Intel HD Graphics 2000")
                {
                    _userParams.Graphics = "Video card must be 128 MB or more and with support for Pixel Shader 2.0b (ATI Radeon X800 or higher / NVIDIA GeForce 7600 or higher / Intel HD Graphics 2000 or higher).";
                }
                else if (update.CallbackQuery.Data == "GeForce 1050 Ti")
                {
                    _userParams.Graphics = "GeForce 1050 Ti / Radeon R9 380";
                }
                else if (update.CallbackQuery.Data == "Radeon R9 380")
                {
                    _userParams.Graphics = "GeForce 1050 Ti / Radeon R9 380";
                }
                else if (update.CallbackQuery.Data == "GTX 1060 6GB / GTX 1660 Super")
                {
                    Random rnd = new Random();
                    int n = rnd.Next(0, 3);
                    if (n == 0)
                    {
                        _userParams.Graphics = "GTX 1060 6GB / GTX 1660 Super or Radeon RX 590";
                    }
                    else if (n == 1)
                    {
                        _userParams.Graphics = "Nvidia GeForce GTX 1060 6GB / AMD Radeon RX 480 4GB";
                    }
                    else if (n == 2)
                    {
                        _userParams.Graphics = "NVidia GTX 1070 OR AMD RX 590";
                    }
                }
                else if (update.CallbackQuery.Data == "Radeon RX 590")
                {
                    Random rnd = new Random();
                    int n = rnd.Next(0, 2);
                    _userParams.Graphics = n == 0 ?  "GTX 1060 6GB / GTX 1660 Super or Radeon RX 590" : 
                                                    "Nvidia GeForce GTX 1060 6GB / AMD Radeon RX 480 4GB";
                }
                else
                {
                    _gamesByGenres.Add(update.CallbackQuery.Data);
                }
            }
        }
        private async Task HandlerMessageAsync(ITelegramBotClient botClient, Message message)
        {
            if (message.Text == "/start")
            {
                _isFound = true;
                await botClient.SendTextMessageAsync(message.Chat.Id, 
                    "Welcome to best game searching bot!\n" 
                    + "We will try to help you find a lot of games depends on your fav genres and PC specs.\n" 
                    + "/menu - to show all commands\n"
                    , cancellationToken: _cancellationToken);
            }
            else if (message.Text == "/menu")
            {
                _isFound = true;
                await botClient.SendTextMessageAsync(message.Chat.Id, 
                    "Bot commands: \n" 
                    + "/menu - to show all commands\n"
                    + "/about - to show bot info\n"
                    + "/games - to find games\n"
                    + "/favorites - to show your elected games", cancellationToken: _cancellationToken);
            } 
            else if (message.Text == "/about")
            {
                _isFound = true;
                await botClient.SendTextMessageAsync(message.Chat.Id, 
                    "Use /menu to see all bot commands. \n" 
                    + "This bot was created by Lorrami and based on web api which is also created by Lorrami.\n"
                    + "You can use bot to find games that will fit your favorite genres and PC specs.\n"
                    + "To start searching type /search and follow the next steps. GG!\n"
                    + "\nIf you have some any problems with bot or any suggestions, feel free to DM @Lorrami!",
                    cancellationToken: _cancellationToken);
            } 
            else if (message.Text == "/games")
            {
                _isFound = true;
                await botClient.SendTextMessageAsync(message.Chat.Id, 
                    "Yeah, let's look for some games: \n" 
                    + "/all - to show all games in database\n"
                    + "/genres - to show available games genres\n"
                    + "/search_game - to start searching by your own parameters\n"
                    + "/search_by_genre - to start search by genre\n"
                    + "/favorites - to show your favorite games\n"
                    + "/add_to_favorites - to add the game to your favorites(command must be send via reply to the games name!!!)\n"
                    + "/delete_all - to delete all from your favorites\n"
                    , cancellationToken: _cancellationToken);
            } 
            else if (message.Text == "/search_game")
            {
                _isFound = true;
                _userParams = new UserParams();
                _continue = false;
                await ChooseProcessor(botClient, message);
                await ChooseGraphics(botClient, message);
                await botClient.SendTextMessageAsync(message.Chat.Id, 
                    "When you will be ready, please type /continue! \n" 
                    , cancellationToken: _cancellationToken);
            }
            else if (message.Text == "/continue")
            {
                _isFound = true;
                if (_userParams.Processor == null || _userParams.Graphics == null)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, 
                        "You did not chose something, please, be attentive. Check and type /continue! \n" 
                        , cancellationToken: _cancellationToken);
                }
                else
                {
                    Client client = new Client();
                    _continue = true;
                    client.PutUserParams(_userParams);
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "Please, wait. We are searching a game for you... \n"
                        , cancellationToken: _cancellationToken);
                    var game = client.GetGameByUserParams();
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "We have found the game " + game.Data.Name + " for you." + '\n' +
                        "You have a " + game.Data.Pc_Requirements.Level + " parameters for it!" + game.Data.Pc_Requirements.Notes + '\n'
                        , cancellationToken: _cancellationToken);
                    if (game.Data.MetaCritic != null)
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id,
                            "Info about " + game.Data.Name + ": \n" +
                            "Official web-site: " + game.Data.WebSite + '\n' +
                            "MetaCritic: " + game.Data.MetaCritic.Score + '\n' +
                            "Minimum PC requirements: \n" +
                            "  OS: " + game.Data.Pc_Requirements.MinimumOS + '\n' +
                            "  Graphics: " + game.Data.Pc_Requirements.MinimumGraphics + '\n' +
                            "  Processor: " + game.Data.Pc_Requirements.MinimumProcessor + '\n' +
                            "  RAM: " + game.Data.Pc_Requirements.MinimumMemory + '\n' +
                            "  Storage: " + game.Data.Pc_Requirements.MinimumStorage + '\n'
                            , cancellationToken: _cancellationToken);
                    } 
                    else
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id,
                            "Info about " + game.Data.Name + ": \n" +
                            "Official web-site: " + game.Data.WebSite + '\n' +
                            "Minimum PC requirements: \n" +
                            "  OS: " + game.Data.Pc_Requirements.MinimumOS + '\n' +
                            "  Graphics: " + game.Data.Pc_Requirements.MinimumGraphics + '\n' +
                            "  Processor: " + game.Data.Pc_Requirements.MinimumProcessor + '\n' +
                            "  RAM: " + game.Data.Pc_Requirements.MinimumMemory + '\n' +
                            "  Storage: " + game.Data.Pc_Requirements.MinimumStorage + '\n'
                            , cancellationToken: _cancellationToken);
                    }
                }
            }
            else if (message.Text == "/search_by_genre")
            {
                _isFound = true;
                _continue = false;
                _gamesByGenres = new List<string>();
                await SearchByGenre(botClient, message);
                await botClient.SendTextMessageAsync(message.Chat.Id, 
                    "When you will be ready, please type /continue_with_genre! \n" 
                    , cancellationToken: _cancellationToken);
            }
            else if (message.Text == "/continue_with_genre")
            {
                _isFound = true;
                if (_gamesByGenres.Count <= 0)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "You did not choose you genres! \n"
                        , cancellationToken: _cancellationToken);
                }
                else if (_gamesByGenres.Count > 3)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "You chose more than 3 genres!(Specifically " + _gamesByGenres.Count + ")\n"
                        , cancellationToken: _cancellationToken);
                }
                else
                {
                    _continue = true;
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "Please, wait. We are searching a game for you... \n"
                        , cancellationToken: _cancellationToken);
                    Client client = new Client();
                    client.PutUserGenres(_gamesByGenres);
                    var gameByGenres = client.GetGameByGenres();
                    foreach (var game in gameByGenres)
                    {
                        if (game.Data.MetaCritic != null)
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                "Info about " + game.Data.Name + ": \n" +
                                "Official web-site: " + game.Data.WebSite + '\n' +
                                "MetaCritic: " + game.Data.MetaCritic.Score + '\n' +
                                "Minimum PC requirements: \n" +
                                "  OS: " + game.Data.Pc_Requirements.MinimumOS + '\n' +
                                "  Graphics: " + game.Data.Pc_Requirements.MinimumGraphics + '\n' +
                                "  Processor: " + game.Data.Pc_Requirements.MinimumProcessor + '\n' +
                                "  RAM: " + game.Data.Pc_Requirements.MinimumMemory + '\n' +
                                "  Storage: " + game.Data.Pc_Requirements.MinimumStorage + '\n'
                                , cancellationToken: _cancellationToken);
                        } 
                        else
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                "Info about " + game.Data.Name + ": \n" +
                                "Official web-site: " + game.Data.WebSite + '\n' +
                                "Minimum PC requirements: \n" +
                                "  OS: " + game.Data.Pc_Requirements.MinimumOS + '\n' +
                                "  Graphics: " + game.Data.Pc_Requirements.MinimumGraphics + '\n' +
                                "  Processor: " + game.Data.Pc_Requirements.MinimumProcessor + '\n' +
                                "  RAM: " + game.Data.Pc_Requirements.MinimumMemory + '\n' +
                                "  Storage: " + game.Data.Pc_Requirements.MinimumStorage + '\n'
                                , cancellationToken: _cancellationToken);
                        }
                    }
                }
            }
            else if (message.Text == "/all")
            { 
                _isFound = true;
                var client = new Client();
                client.GetGamesList();
                foreach (var game in Client.Result)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, 
                        game.Data.Name+'\n'
                        , cancellationToken: _cancellationToken);
                }
            } 
            else if (message.Text == "/genres")
            {
                _isFound = true;
                await botClient.SendTextMessageAsync(message.Chat.Id, 
                    "All genres you can choose from:\n "
                    , cancellationToken: _cancellationToken);
                foreach (var genre in _genres)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, 
                        genre + '\n'
                        , cancellationToken: _cancellationToken);
                }
            }
            else if (message.Text == "/favorites")
            {
                Client client = new Client();
                var list = await client.GetGamesFromDB(message);
                if (list.Count > 0)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "Your favorite games: \n"
                        , cancellationToken: _cancellationToken);
                    foreach (var game in list)
                    {
                        if (game != null)
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                game.Data.Name + "\n"
                                , cancellationToken: _cancellationToken);
                        }
                    }
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                         "You do not have any favorite games for now.\n"
                         + "You can add them using /add_to_favorites via reply for the game!"
                        , cancellationToken: _cancellationToken);
                }
            }
            else if (message.Text == "/add_to_favorites")
            {
                var name = message.ReplyToMessage?.Text;
                if (name == null)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, 
                        "This command must be send via reply to computers name!!!\n" 
                        , cancellationToken: _cancellationToken);
                }
                else
                {
                    Client client = new Client();
                    var list = client.GetGamesList();
                    bool found = false;
                    foreach (var game in list)
                    {
                        if (name == game.Data.Name)
                        {
                            found = true;
                            client.PutGamesIntoDB(message, Convert.ToString(game.Data.Id));
                            await botClient.SendTextMessageAsync(message.Chat.Id, 
                                "Successfully added to your favorites!\n" 
                                , cancellationToken: _cancellationToken);
                        }
                        else
                        {
                            found = false;
                        }
                    }

                    if (found)
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, 
                            "Ypu missed with the reply!\n"
                            + "We did not find that game. Try again!"
                            , cancellationToken: _cancellationToken);
                    }
                }
            }
            else if (message.Text == "/delete_all")
            {
                Client client = new Client();
                client.DeleteGameFromDB(message);
                await botClient.SendTextMessageAsync(message.Chat.Id,
                    "Successfully deleted all from your favorites!\n"
                    , cancellationToken: _cancellationToken);
            }
            else
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, 
                    "Wrong command, you check available commands by typing /menu! \n" 
                    , cancellationToken: _cancellationToken);
            }
        }

        private Task HandlerError(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException =>
                    $"Exception in telegram bot API:\n{apiRequestException.ErrorCode}" +
                    $"\n{apiRequestException.Message}",
                _ => exception.ToString()
            };
            Console.WriteLine(errorMessage);
            return Task.CompletedTask;
        }

        private async Task SearchByGenre(ITelegramBotClient botClient, Message message)
        { 
            InlineKeyboardMarkup keyboardMarkup = new
            (
                new[]
                {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Action", "Action"),
                        InlineKeyboardButton.WithCallbackData("Multi-player", "Multi-player"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("MMO", "MMO"),
                        InlineKeyboardButton.WithCallbackData("PvP", "PvP"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Adventure", "Adventure"),
                        InlineKeyboardButton.WithCallbackData("Co-op", "Co-op"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Strategy", "Strategy"),
                        InlineKeyboardButton.WithCallbackData("Simulation", "Simulation"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Single-player", "Single-player"),
                        InlineKeyboardButton.WithCallbackData("RPG", "RPG"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Racing", "Racing"),
                        InlineKeyboardButton.WithCallbackData("Sports", "Sports"),
                    },
                }
            );
            await botClient.SendTextMessageAsync(message.Chat.Id, "Choose which game genre are you interested in(no more than 3):\n", replyMarkup: keyboardMarkup);
        }
        private async Task ChooseProcessor(ITelegramBotClient botClient, Message message)
        {
            InlineKeyboardMarkup keyboardMarkup = new
            (
                new[]
                {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Weaker Than All", "Weaker")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Pentium 4", "Pentium4")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Dual Core 2.0 or AMD64X2", "DualCore2orAMD64X2"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Intel Core 2 Duo", "IntelCore2Duo"),
                        InlineKeyboardButton.WithCallbackData("AMD Phenom X3", "AMDPhenomX3")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Intel Core i3-530", "IntelCoreI3-530"),
                        InlineKeyboardButton.WithCallbackData("AMD Athlon II X3", "AMDAthlonIIx3")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Intel Core i5 3470", "IntelCoreI53470"),
                        InlineKeyboardButton.WithCallbackData("AMD Athlon 240GE", "AMDAthlon240GE")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Intel Core i5-2500K", "Intel®Core™i5-2500K"),
                        InlineKeyboardButton.WithCallbackData("AMD FX-6300", "AMDFX-6300")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Intel Core i5-3570K", "IntelCorei5-3570K"),
                        InlineKeyboardButton.WithCallbackData("AMD Phenom II X4 940", "AMDPhenomIIX4940")

                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Intel Core i5-4460", "Inteli5-4460"),
                        InlineKeyboardButton.WithCallbackData("AMD FX-8310", "AMDFX-8310")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Intel Core i5-8400", "Inteli5-8400"),
                        InlineKeyboardButton.WithCallbackData("AMD Ryzen 3 1200", "AMDRyzen31200")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Intel Core i5-750", "Intel® Core™ i5-750"),
                        InlineKeyboardButton.WithCallbackData("AMD Phenom™ II X4 955", "AMD Phenom™ II X4 955")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Intel Core i5-2400S", "Intel® Core™ i5-2400S"),
                        InlineKeyboardButton.WithCallbackData("AMD FX-8350", "AMD FX-8350")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Intel Core i5 or AMD Ryzen", "IntelCorei5orAMDRyzen")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Intel Core i7-3770", "IntelCorei737703.4GHz"),
                        InlineKeyboardButton.WithCallbackData("AMD FX-8350 4 GHz", "AMDFX-83504GHz")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Intel Core i7-4790", "IntelCorei7-4790"),
                        InlineKeyboardButton.WithCallbackData("AMD Ryzen 3 3200G", "AMDRyzen33200G")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Intel Core i7-4770K", "Intel®Core™i7-4770K"),
                        InlineKeyboardButton.WithCallbackData("AMD Ryzen 5 1500X", "AMDRyzen51500X")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Stronger Than All", "Stronger"),
                    }
                }
            );
            await botClient.SendTextMessageAsync(message.Chat.Id, "Choose your processor model:\n(if you do not see your model, please, choose the closest to yours)", replyMarkup: keyboardMarkup);
        }
        private async Task ChooseGraphics(ITelegramBotClient botClient, Message message)
        {
            InlineKeyboardMarkup keyboardMarkup = new
            (
                new[]
                {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Weaker Than All", "WeakerGraphics")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Skip", "Skip")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("GeForce 250 GTS","GeForce 250 GTS"), 
                        InlineKeyboardButton.WithCallbackData("Radeon HD 4850","Radeon HD 4850")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("GeForce 500 Series","GeForce 500 Series"), 
                        InlineKeyboardButton.WithCallbackData("Radeon HD 7000 Series","Radeon HD 7000 Series")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Intel HD Graphics 500 Series","Intel HD Graphics 500 Series")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("GeForce GTX 460","GeForce GTX 460"),
                        InlineKeyboardButton.WithCallbackData("Radeon HD 5850","Radeon HD5850"), 
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("GeForce GTX 660","GeForce GTX 660"),
                        InlineKeyboardButton.WithCallbackData("Radeon HD 7870","Radeon HD 7870"), 
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("GeForce GTX 680","GeForce GTX 680"),
                        InlineKeyboardButton.WithCallbackData("Radeon R9 290X","Radeon R9 290X"), 
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("GeForce GTX 960","GeForce GTX 960"),
                        InlineKeyboardButton.WithCallbackData("Radeon R9 280","Radeon R9 280"), 
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("GeForce GTX 770","GeForce GTX 770"),
                        InlineKeyboardButton.WithCallbackData("Radeon R9 290","Radeon R9 290"), 
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("GeForce GTX 970","GeForce GTX 970"),
                        InlineKeyboardButton.WithCallbackData("Radeon RX 470","Radeon RX 470"), 
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("GeForce 7600","GeForce 7600"), 
                        InlineKeyboardButton.WithCallbackData("Radeon X800","Radeon X800")
                    }, 
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Intel HD Graphics 2000","Intel HD Graphics 2000")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("GeForce 1050 Ti", "GeForce 1050 Ti"), 
                        InlineKeyboardButton.WithCallbackData("Radeon R9 380", "Radeon R9 380"), 
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("GTX 1060 6GB / GTX 1660 Super", "GTX 1060 6GB / GTX 1660 Super"), 
                        InlineKeyboardButton.WithCallbackData("Radeon RX 590", "Radeon RX 590"), 
                    },
                }
            );
            await botClient.SendTextMessageAsync(message.Chat.Id, "Choose your graphics card model:\n(if you do not see your model, please, choose the closest to yours)", replyMarkup: keyboardMarkup);
        }
    }
}