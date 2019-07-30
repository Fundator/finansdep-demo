# Demonstrasjon av forklarbar prediksjon av boligpriser
Demoapplikasjonen er tilgjengelig her: https://finansdep-demo.azurewebsites.net/

Datasettet som ble brukt for å trene opp modellen er [Melbourne Housing Clearance Data (2016) from Kaggle](https://www.kaggle.com/anthonypino/melbourne-housing-market).

# Hvordan det fungerer
![Architecture drawing](https://github.com/Fundator/finansdep-demo/blob/master/finansdep-ark.png?raw=true)
Modellen er trent og rullet ut som en _container instance_ i Azure. Fra denne containeren eksponeres et [REST-API ved hjelp av Flask](http://5364e0bd-1a4e-4579-98de-4bd9b11ca807.westus.azurecontainer.io/score). Dette API'et benyttes av backenden til denne demoapplikasjonen, som er skrevet i C#/.NET Core. Frontenden er skrevet i TypeScript og Angular 8, og bruker et [forenklet REST-API](https://finansdep-demo.azurewebsites.net/swagger) eksponert fra kontrolleren [PredictionController](https://github.com/Fundator/finansdep-demo/blob/master/Finansdep.Demo.WebUI/Finansdep.Demo.WebUI/Controllers/PredictionController.cs) i backenden.

# Kjøring av applikasjonen lokalt
For å kjøre applikasjonen må man installere Visual Studio 2019 Community Edition, .NET Core SDK 2.2, og NodeJS. Ved første bygging/kjøring vil det gjennomføres en førstegangsinstallasjon av pakkene i ClientApp\packages.json, og dette kan ta noe tid. Applikasjonen vil fortsatt benytte prediksjons-API'et fra containeren som kjører i Azure.

# Useful resources
- Link til demoapplikasjon: https://finansdep-demo.azurewebsites.net/
- API-dokumentasjon: https://finansdep-demo.azurewebsites.net/swagger
- Kildekode Web Frontend/Backend (dette repoet): https://github.com/Fundator/finansdep-demo
- Kildekode MLFlow Backend: https://github.com/Fundator/finansdep
- Vår webside: https://www.nois.no/produkter/IT-tjenester/
