# Esercitazione Fianle
Si richiede di sviluppare un applicativo per la gestione del personale di una societ&agrave; di consulenza.

1. Dopo aver effettuato log in, l'utente potr&agrave; vedere la lista dei dipendenti, ma sar&agrave; gestibile solo da utenti con ruolo di amministratore
2. L'utente potr&agrave; vedere la lista dei clienti, ma sar&agrave; gestibile solo da utenti con ruolo di amministratore
3. Ogni dipendente deve poter tracciare il lavoro svolto attraverso timesheets
4. Visualizzare un recap delle attivit&agrave; per dipendente per mese

## Technicalities
- Realizzare un progetto Core per la BL
- Realizzare un progetto progetto per il DAL
    - Utilizzare il Repository Pattern
    - Utilizzare EF con metodologia *Code First*
- Realizzare un progetto per gli UnitTests
- Realizzare un'applicazione ASP.NET Core MVC
- Realizzare un'applicazione console

Decidere quali funzionalit&agrave; rendere accessibili tramite applicazione MVC e quali tramite console app, e motivare le proprie scelte.

*N.B.* Si ritiene necessario che le funzionalit&agrave; vengano suddivise tra i due tipi di applicazioni.

---
- Definire la struttura dei **dipendenti** 
    - id
    - nome
    - cognome
    - data di nascita
    - email
    - data di assunzione
    - mansione
    - costo orario per l'azienda

- Definire la struttura dei **clienti**, delle **commesse** e le attivit&agrave; della singola commessa.

- Popolare il database con almeno 3 diversi clienti, 4 diversi dipendenti, almeno una commessa per ogni cliente, e almeno una attivit&agrave; per ogni commessa. Per ogni attivit&agrave; di commessa associare almeno un dipendente.

Il database da utilizzare deve essere SQL Azure.

---
Il tutto sar&agrave; deployato su Azure VM. 

La gestione del progetto dovr&agrave; essere realizzata in Azure DevOps, e verra&agrave; valutata l'applicazione dell'Agile Manifesto in tute le sue parti, per questo motivo bisogner&agrave; inserire il docnte come amministratore di progetto (in modo che possa avere accesso al progetto nella sua interezza, una volta consegnato).