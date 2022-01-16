# RS2 - Seminarski - eFrizer

**eFrizer** je aplikacija koja služi za pregled zauzetih i slobodnih termina , te rezervaciju vlastitog termina sa željenim servisom .Aplikacija je podijeljena u dva dijela:
-	desktop aplikacija namijenjena administratorima za upravljanje sadržajem,
-	mobilna aplikacija namijenjena korisnicima za pregled i filtriranje sadržaja.

## Kredencijali za prijavu   

### Desktop aplikacija

- Manager

    ```
    Korisnicko ime: muser                       
    ```  

### Mobilna aplikacija

- Klijent

    >**Napomena**: zbog recommendera postoji više klijentskih profila
    ```
    Korisnicko ime: aclient                                              
    Lozinka: 1234     
    ```
- HairDresser

    ```
    Korisnicko ime: hairdresser2                                              
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
    docker-compose build
    docker-compose up
    ```
    
4. Otovriti flutter_frizer folder

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

    ```
    1. Otvoriti solution u Visual Studiu
    2. Desni klik na solution
    3. Set Startup Projects
    4. Multiple startup projects
    5. eFrizer.Win - Start
    6. OK
    7. CTRL + F5
    ```    
