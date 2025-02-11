### <p align="center"> How to run the Music-Store </p>
 
> [!IMPORTANT]   
> If you forked this repository, you need to ***add your own connection string in this directory***, in order to run the console-application.
> <br>
> The file should be named `mssql.txt` and should contain the connection string to your SQL Server database.
> <br>
> <br>
> The connection string should be in the following format: 
>
> ```
> Data Source=[IP],[PORT];Database=[NAME_OF_YOUR_DB];User Id=[YOUR_USER];Password=[YOUR_PW];TrustServerCertificate=true
> ```

---

> [!WARNING]
> You also need to ***add your own credentials in this directory***, in order to log into the web-application.
> <br>
> The file should be named `credentials.csv` and should contain the credentials you want to use.
> <br>
> <br>
> The csv-file should have the following content: [^1]
>
> ```
> Name;Password;Role
> [YOUR_ADMIN_NAME];[YOUR_PW];[YOUR_ROLE]
> ```

[^1]: *The program skips the first row (header) of the file, while checking!* 
 
