export class User
{
    Id: number;
    UserName: string;
    Password: string;
    DisplayName?: string;
    Email?: string;

    constructor(Id: number, UserName: string, Password: string, DisplayName?: string, Email?: string)
    {
        this.Id = Id;
        this.UserName = UserName;
        this.Password = Password;
        this.DisplayName = DisplayName;
        this.Email = Email;
    }
}