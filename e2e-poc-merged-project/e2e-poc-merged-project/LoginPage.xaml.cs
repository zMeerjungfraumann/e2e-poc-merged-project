namespace e2e_poc_merged_project
{
    public partial class LoginPage : ContentPage
    {
        public List<User> userList = new List<User>() { new User("Dennis", "dennis.cvjeticanin@gmx.at", "1234") };

        public LoginPage()
        {
            InitializeComponent();
        }

        private void showLogin(object sender, EventArgs e)
        {
            displayLogin();
        }

        public void displayLogin()
        {

            hideElements();
            txtfUsername.IsVisible = true;
            txtfPassword.IsVisible = true;
            lblLogin.IsVisible = true;
            btBack.IsVisible = true;
            btLogin.IsVisible = true;
            lblUsername.IsVisible = true;
            lblPassword.IsVisible = true;

        }

        public void showRegister(object sender, EventArgs e)
        {

            displayRegister();
        }

        public void displayRegister()
        {

            hideElements();
            lblRegister.IsVisible = true;
            lblUsernameReg.IsVisible = true;
            txtfUsernameReg.IsVisible = true;
            lblEmailReg.IsVisible = true;
            txtfEmailReg.IsVisible = true;
            lblPasswordReg.IsVisible = true;
            txtfPasswordReg.IsVisible = true;
            lblEmailReg.IsVisible = true;
            btRegister.IsVisible = true;
            btBack.IsVisible = true;  
        }

        public void showMenu(object sender, EventArgs e)
        {
            hideElements();
            btStartLogin.IsVisible = true;
            lblMenu.IsVisible = true;
            btStartRegister.IsVisible = true;
            

            //Clear Values
            txtfUsername.Text = "";
            txtfPassword.Text = "";

            txtfEmailReg.Text = "";
            txtfUsernameReg.Text = "";
            txtfPasswordReg.Text = "";
        }

        public async void startLogin(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Username: (" + txtfUsername.Text.ToUpper() + "), Password: (" + txtfPassword.Text + ")");

            //Durch Datenbankzugriff ersetzen
            //Nachschauen, ob der User in der Liste ist
            for (int i = 0; i < userList.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("-----------start forLogin");
                System.Diagnostics.Debug.WriteLine("List[" + i + "]: " + userList[i].username.ToUpper());
                System.Diagnostics.Debug.WriteLine("List[" + i + "]: " + userList[i].password);
                System.Diagnostics.Debug.WriteLine("List[" + i + "]: " + userList[i].email.ToUpper());

                //User ist in der Liste vorhanden
                if ((userList[i].username.ToUpper() == txtfUsername.Text.ToUpper()) && (userList[i].password == txtfPassword.Text))
                {
                    System.Diagnostics.Debug.WriteLine("User was found!");
                    System.Diagnostics.Debug.WriteLine(userList[i].username.ToUpper() + "==" + txtfUsername.Text.ToUpper());
                    System.Diagnostics.Debug.WriteLine(userList[i].password + "==" + txtfPassword.Text);

                    lblLoginInformation.IsVisible = true;
                    lblLoginInformation.Text = "Successfully logged in!";

                    await Task.Delay(1000); //Wait without blocking UI-Thread

                    showLoggedInScreen(txtfUsername.Text);
                    break;

                }else{ //User ist nicht in der Liste vorhanden
                    System.Diagnostics.Debug.WriteLine(userList[i].username.ToUpper() + "!=" + txtfUsername.Text.ToUpper());
                    System.Diagnostics.Debug.WriteLine(userList[i].password + "!=" + txtfPassword.Text);
                    System.Diagnostics.Debug.WriteLine("-----------end forLogin");
                    lblLoginInformation.IsVisible = true;
                    lblLoginInformation.Text = "This User wasn't found or Password is incorrect! Try again!";
                }
            }
        }

        public async void startRegister(object sender, EventArgs e)
        {

            bool usernameFree = true;
            System.Diagnostics.Debug.WriteLine("in startRegister");
            //Schauen ob der User bereits in der Liste ist
            for (int i = 0; i < userList.Count; i++)
            {

                System.Diagnostics.Debug.WriteLine("-----------start forRegister");
                System.Diagnostics.Debug.WriteLine("List[" + i + "]: " + userList[i].username.ToUpper());
                System.Diagnostics.Debug.WriteLine("List[" + i + "]: " + userList[i].password);

                //User gibt es schon
                if (userList[i].username.ToUpper() == txtfUsernameReg.Text.ToUpper())
                {

                    System.Diagnostics.Debug.WriteLine("Username is taken.");
                    System.Diagnostics.Debug.WriteLine(userList[i].username.ToUpper() + "==" + txtfUsernameReg.Text.ToUpper());
                    System.Diagnostics.Debug.WriteLine(userList[i].password + "==" + txtfPasswordReg.Text);
                    lblRegisterInfo.IsVisible = true;
                    lblRegisterInfo.Text = "The username is already taken! Try again!";
                    usernameFree = false;

                }else{//User gibt es noch nicht

                    System.Diagnostics.Debug.WriteLine(userList[i].username.ToUpper() + "!=" + txtfUsernameReg.Text.ToUpper());
                    System.Diagnostics.Debug.WriteLine(userList[i].password + "!=" + txtfPasswordReg.Text);
                }

                System.Diagnostics.Debug.WriteLine("-----------end forRegister");

            }

            //Wenn es User noch nicht gibt, User zur Liste hinzufügen
            if (usernameFree)
            {

                System.Diagnostics.Debug.WriteLine("Username is free, creating User.");
                lblRegisterInfo.IsVisible = true;
                lblRegisterInfo.Text = "User was created!";
                userList.Add(new User(txtfUsernameReg.Text.ToUpper(), txtfEmailReg.Text.ToUpper(), txtfPasswordReg.Text));

                txtfUsernameReg.IsEnabled = false;
                txtfEmailReg.IsEnabled = false;
                txtfPasswordReg.IsEnabled = false;

                await Task.Delay(1000); //Wait without blocking UI-Thread

                hideElements();
                displayLogin();
            }
        }

        public async void showLoggedInScreen(string name)
        {
            await Navigation.PushAsync(new LoggedInPage()); // Navigate to the new page
        }

        public void hideElements()
        {
            btStartLogin.IsVisible = false;
            lblMenu.IsVisible = false;
            txtfUsername.IsVisible = false;
            txtfPassword.IsVisible = false;
            lblLogin.IsVisible = false;
            btBack.IsVisible = false;
            btLogin.IsVisible = false;
            lblUsername.IsVisible = false;
            lblPassword.IsVisible = false;
            lblLoginInformation.IsVisible = false;
            btStartRegister.IsVisible = false;
            lblRegister.IsVisible = false;
            lblUsernameReg.IsVisible = false;
            txtfUsernameReg.IsVisible = false;
            lblEmailReg.IsVisible = false;
            txtfEmailReg.IsVisible = false;
            lblPasswordReg.IsVisible = false;
            txtfPasswordReg.IsVisible = false;
            btRegister.IsVisible = false;
            lblRegisterInfo.IsVisible = false;
            txtfEmailReg.IsVisible = false;
        }

        public class User
        {
            public string username;
            public string email;
            public string password;

            public User(string username, string email, string password)
            {

                this.username = username;
                this.email = email;
                this.password = password;
            }
        }
    }
}