# RS2 - Seminarski - eFrizer

**eFrizer** je aplikacija čija je osnovna svrha olakšavanje poslovnih procesa u poslu frizerskog salona. Rješenje je podijeljeno na dva dijela:
-	desktop aplikacija namijenjena menadžerima frizerskih salona
-	mobilna aplikacija namijenjena korisnicima i frizerima

## Kredencijali za prijavu   

### Desktop aplikacija

- Manager

    ```
    Korisnicko ime: muser 
    Password: 1234
    ```  

### Mobilna aplikacija

- Klijent

    >**Napomena**: Za sve ostale klijentske profile je šifra ista.
    ```
    Korisnicko ime: aclient                                              
    Lozinka: 1234     
    ```
    
- HairDresser

    ```
    Korisnicko ime: hairdresser1                                             
    Lozinka: 1234     
    ```

## Pokretanje aplikacija
1. Kloniranje repozitorija

    ```
    git clone https://github.com/Nokee221/eFrizer
    ```
2. Otvoriti klonirani repozitoriji u konzoli

3. Pokretanje dokerizovanog API-ja i DB-a


    ```
    cd eFrizer
    docker-compose build
    docker-compose up
    ```
    
4. Otvoriti flutter_frizer folder

    ```
    cd flutter_frizer
    ```

5. Dohvatanje dependecy-a

    ```
    flutter pub get
    ```
    
6. Pokretanje mobilne aplikacije

    ```
    flutter run
    ```   
    
7. Pokretanje desktop aplikacije

    cd eFrizer.Win

    dotnet run

    ILI
    ```
    1. Otvoriti solution u Visual Studiu
    2. Desni klik na solution
    3. Set Startup Projects
    4. Multiple startup projects
    5. eFrizer.Win - Start
    6. OK
    7. CTRL + F5
    ```    
