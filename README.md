Projekat je uzet sa privatnog repozitorijuma iz predmeta specifikacija i modeliranje softvera na kom smo radili u timu od četvoro. Moja je bila uloga turiste. U fajlu: "HCI.txt" se nalaze moje specifikacije za frontend.

*Tutorijali nisu dodati na git jer su prevelikog formata.

Specifikacija i modeliranje softvera 2023/2024 Timski projekat


TIMSKA FUNKCIONALNOST

● Prijava i odjava korisnika: Omogućiti prijavu i odjavu svih korisnika. Svi korisnici, bez obzira
na njihovu ulogu, treba da se prijavljuju pomoću jedne (iste) forme za unos korisničkog
imena i lozinke. U zavisnosti od uloge korisnika, prikazuje se odgovarajući ekran.

1 VLASNIK

● Registracija smeštaja: Vlasnik može da registruje novi smeštaj. Prilikom registracije, vlasnik
unosi sledeće podatke:
1. Naziv
2. Lokacija: grad i država
3. Tip (apartman, kuća, koliba)
4. Max broj gostiju
5. Min broj dana za rezervaciju
6. Broj dana pred rezervaciju do kog je moguće otkazati rezervaciju (podrazumevana
vrednost je jedan dan, a vlasnik može zadati neki drugi broj)
7. Jedna ili više slika (za svaku sliku navesti putanju do slike)
   
● Statistika o smeštaju: Vlasnik bira smeštaj za koju želi statistiku, nakon čega će se prikazati
statistika po godinama, gde je za svaku godinu prikazan broj rezervacija u toj godini za
izabrani smeštaj, broj otkazivanja rezervacija, broj pomeranja rezervacija i broj preporuka za
renoviranje. Ako vlasnik odabere jednu konkretnu godinu, dobiće sve prethodno nabrojane
informacije, ali po mesecima u izabranoj godini. Pored toga, prikazati vlasniku u kojoj je
godini (ili mesecu) izabrani smeštaj bio najviše zauzet. Zauzetost se gleda kao broj dana kada
je smeštaj bio zauzet u odnosu na ukupan broj dana u mesecu ili godini.

● Predlog za registraciju novog smeštaja ili uklanjanje postojećeg: Na osnovu statistika o
rezervacijama, sistem može predložiti vlasniku da postoji dobra prilika za otvaranje još
jednog smeštaja na najpopularnijim lokacijama. Najpopularnije lokacije su one na kojima se
nalaze smeštaji sa najvećim brojem rezervacija i najvećim procentom zauzetosti (koliki broj
gostiju je bio na svakoj rezervaciji u odnosu na maksimalan mogući broj gostiju). Sa druge
strane, za nepopularne lokacije (najmanji broj rezervacija i najmanji procenat zauzetosti)
sistem može predložiti zatvaranje postojećih smeštaja. Omogućiti vlasniku uvid u ove
predloge.

● Upravljanje zahtevima za pomeranje rezervacije: Vlasnik može odobriti ili odbiti zahteve
za pomeranje rezervacije (promena datuma rezervacije). Vlasnik vidi sve zahteve koje su
gosti napravili, pri čemu mu sistem pruža informaciju da li su novi datumi za koje je gost
uputio zahtev već rezervisani. Vlasnik može odobriti ili odbiti zahtev, bez obzira da li mu je
sistem javio da su novi datumi zauzeti (npr. može se desiti da je neko otkazao rezervaciju
preko telefona, pa da informacija nije uneta u sistem, te se i dalje prikazuje da je smeštaj
zauzet, a zapravo su neki datumi oslobođeni). Vlasnik može uneti obrazloženje prilikom
odbijanja zahteva. Ako vlasnik odobri promenu, ona će se automatski ubeležiti tj.
promeniće se datumi na rezervaciji.

● Ocenjivanje gostiju: Nakon što gost završi posetu smeštaju, vlasnik dobija mogućnost da
ga oceni. Rok za ocenjivanje je 5 dana, nakon čega više nije moguće oceniti gosta. Sistem
treba da šalje vlasniku obaveštenja svaki dan kako bi ga podsetio da još uvek nije ocenio
gosta (obaveštenja prestaju kada vlasnik oceni gosta). Vlasnik popunjava nekoliko kategorija
pri ocenjivanju: čistoća (1-5), poštovanje pravila (1-5) i dodatan komentar.

● Prikaz recenzija: Vlasnik može videti ocene koje je dobio od svojih gostiju tek nakon što i on
oceni svoje goste, kako bi se očuvala objektivnost davanja ocena.

● Super-vlasnik: Vlasnik može postati super-vlasnik ukoliko ima bar 50 ocena od gostiju, pri
čemu prosek mora biti iznad 4.5 (npr. jedna ocena je prosek ocene koja je njemu data -
korektnost i ocene koja je data za smeštaj - čistoća). Čim ocena padne ispod 4.5, vlasnik
gubi titulu super-vlasnika, a može je ponovo osvojiti ukoliko se prosek podigne na 4.5.
Super-vlasnik znači da će svi smeštaji ovog vlasnika biti prvi prikazani gostima prilikom
pregleda ili pretrage smeštaja, kao i da će biti posebno naznačeni gostima (npr. nekom
zvezdicom).

● Zakazivanje renoviranja: Vlasnik bira smeštaj koji želi da renovira, unosi opseg datuma
(početni i krajnji) kada bi želeo da zakaže renoviranje, i upisuje predviđeno trajanje
renoviranja. Sistem treba da pronađe slobodne termine u zadatom trajanju u opsegu
datuma koji je zadat. Slobodni termini su oni u kojima ne postoje rezervacije. Vlasnik bira
jedan od slobodnih termina i unosi opis renoviranja. U terminu zakazanog renoviranja gost
ne može zakazati boravak u smeštaju.

● Prikaz i otkazivanje zakazanih renoviranja: Prikazati vlasniku sva prethodna i buduća
(zakazana) renoviranja njegovih smeštaja. Omogućiti otkazivanje zakazanih renoviranja
samo ako do renoviranja ima više od 5 dana.

● Obaveštenje o novom forumu i ostavljanje komentara na forumu: Kada gost otvori
forum za lokaciju na kojoj vlasnik ima bar jedan smeštaj, vlasnik dobija obaveštenje da se
forum otvorio i može ostaviti komentar. Samo vlasnici koji imaju smeštaj na toj lokaciji mogu
ostavljati komentare. Komentar će biti posebno naznačen da je od vlasnika koji poseduje
smeštaj na toj lokaciji. Forumi koji dostignu 10 komentara vlasnika (i 20 komentara gostiju
koji su bili na toj lokaciji) će biti označeni kao veoma korisni.

● Prijava komentara na forumu: Vlasnik može prijaviti komentare gostiju koji nikada nisu bili
na lokaciji, a ostavili su netačne komentare na forumu. Broj prijava na određenom
komentaru na forumu je vidljiv svima na forumu, kako bi znali koji komentari su možda
nevalidni, jer su ostavljeni od strane gostiju koji (bar po podacima ove aplikacije) nisu bili na
toj lokaciji.

2 GOST

● Prikaz i pretraga smeštaja: Gost može pregledati sve ponuđene smeštaje ili ih pretražiti
po sledećim parametrima:
1. Naziv (prilikom pretrage voditi računa da se prikažu smeštaji koji sadrže u nazivu ono što
je gost zadao)
2. Lokacija: grad i država
3. Tip (apartman, kuća, koliba)
4. Broj gostiju (prilikom pretrage treba voditi računa da ovaj broj ne prelazi max broj gostiju
koji je vlasnik zadao)
5. Broj dana za rezervaciju (prilikom pretrage voditi računa da ovaj broj nije manji od min
broja dana za rezervaciju koji je vlasnik zadao)

● Rezervacija smeštaja: Gost bira jedan od smeštaja, unosi opseg datuma za koji bi želeo da
izvrši pretragu slobodnih datuma (početni i krajnji datum) i broj dana za boravak u smeštaju.
Sistem treba da vodi računa o minimalnom broju dana za koji je moguće izvršiti rezervaciju
(koji je vlasnik uneo) i ne sme dozvoliti gostu kršenje ovog ograničenja. Sistem pronalazi
datume u zadatom opsegu datuma kada je smeštaj slobodan (onoliko dana koliko je gost
uneo). Ako smeštaj nije slobodan u navedenom opsegu datuma za navedeni broj dana,
sistem predlaže druge slobodne datume (pri čemu treba da ispoštuje broj dana koji je gost
zadao) van opsega datuma koje je gost uneo. Kada se pronađu slobodni datumi za izabrani
smeštaj, gost bira jedan od ponuđenih i unosi broj ljudi koji dolaze, pri čemu se ne sme
prekršiti max broj gostiju koji je vlasnik zadao. Voditi računa da se rezervisani smeštaj označi
kao zauzet u odabranim datumima.

● Ocenjivanje smeštaja i vlasnika: Gost može oceniti smeštaj i njegovog vlasnika nakon
boravka, ali ne kasnije od 5 dana nakon boravka. Gost popunjava nekoliko kategorija pri
ocenjivanju: čistoća (1-5), korektnost vlasnika (1-5) i dodatan komentar. Gost može ostaviti
jednu ili više slika smeštaja (za svaku sliku navesti putanju do slike).

● Preporuka za renoviranje: Gost može napisati vlasniku preporuku za renoviranje u
nastavku recenzije (iz funkcionalnosti “Ocenjivanje smeštaja i vlasnika”). U toj preporuci je
potrebno popuniti informacije o stanju smeštaja (šta je bilo loše tj. šta bi trebalo renovirati)
i koliko je to renoviranje nepohodno tj. nivo hitnosti renoviranja. Šta koji nivo znači je
objašnjeno u nastavku:

Nivo 1 - bilo bi lepo renovirati neke sitnice, ali sve funkcioniše kako treba i bez toga

Nivo 2 - male zamerke na smeštaj koje kada bi se uklonile bi ga učinile savršenim

Nivo 3 - nekoliko stvari koje su baš zasmetale bi trebalo renovirati

Nivo 4 - ima dosta loših stvari i renoviranje je stvarno neophodno

Nivo 5 - smeštaj je u jako lošem stanju i ne vredi ga uopšte iznajmljivati ukoliko se ne
renovira

● Prikaz recenzija: Gost može videti ocene koje je dobio od vlasnika kod kojih je bio u
smeštaju, ali tek nakon što i on oceni vlasnike, kako bi se očuvala objektivnost davanja
ocena.

● Prikaz i slanje zahteva za pomeranje rezervacije: Gost može poslati vlasniku zahtev za
pomeranje prethodno napravljene rezervacije. Gost unosi nove datume za rezervaciju koje
vlasnik mora odobriti. Gost može da vidi sve zahteve: na čekanju, odobrene ili odbijene, kao
i komentare vlasnika. Kada vlasnik odobri ili odbije zahtev, gostu će stići obaveštenje da je
došlo do promene statusa zahteva.

● Otkazivanje rezervacija: Gost može otkazati rezervaciju najkasnije 24h pre datuma početka
boravka, ukoliko ne postoje druga ograničenja koja je vlasnik postavio i tada se ona moraju
ispoštovati (npr. vlasnik je podesio da je moguće otkazati rezervaciju 3 dana pre). Kada se
otkaže rezervacija, šalje se obaveštenje vlasniku i smeštaj postaje slobodan u tim
datumima.

● “Bilo gde/bilo kada”: Gost unosi broj ljudi, opseg datuma kada bi želeo da putuje i na
koliko dana. Sistem pronalazi slobodne smeštaje u zadatom opsegu datuma na bilo kojoj
lokaciji koji imaju prostora za taj broj ljudi i za onoliko dana koliko je naznačeno. Ako gost ne
unese opseg datuma, onda se traže smeštaji koji su slobodni bilo kada za zadati broj ljudi i
broj dana. Kada pronađe slobodne smeštaje, sistem ih prikazuje gostu i nudi pronađene
slobodne termine koje gost može odabrati i time izvršiti rezervaciju.

● Super-gost: Gost može postati super-gost ako u prethodnih godinu dana ima bar 10
rezervacija. Super-gost titula traje godinu dana i prestaje da važi ako gost ne bude ponovo
zadovoljio uslov od 10 rezervacija. Super-gost dobija 5 bonus poena koje može potrošiti u
narednih godinu dana, nakon čega se bodovi resetuju na 0 (ako gost ne uspe da održi titulu
super-gosta onda mu se svakako brišu bonus poeni, a ako uspe da produži onda se resetuju i
dobija 5 novih, dakle ne mogu se akumulirati). Prilikom svake naredne rezervacije se troši
jedan bonus poen što donosi popuste, što znači da će super-gost imati 5 rezervacija sa
popustom (popusti i plaćanje je nešto što je van ove aplikacije, recimo da se to odvija uživo
sa vlasnikom).

● Otvaranje foruma: Gost može da pokrene forum za neku lokaciju kako bi se prikupila
iskustva drugih ljudi. Gost navodi lokaciju i ostavlja prvi komentar (npr. neka pitanja na koja
bi želeo da dobije odgovor). Gost koji je otvorio forum ga može zatvoriti u bilo kom
momentu, ali ne može ga obrisati tj. on ostaje vidljiv zauvek.

● Ostavljanje komentara na forumu: Bilo koji gost može ostavljati komentare na otvoren
forum, ali ako je gost nekada bio na zadatoj lokaciji (postoji rezervacija na toj lokaciji) njegov
komentar će biti posebno označen. Forumi koji dostignu 20 komentara od strane gostiju koji
su već posetili tu lokaciju (i 10 od vlasnika koji poseduju smeštaje na toj lokaciji) će biti
označeni kao veoma korisni.

3 VODIČ

● Kreiranje ture: Vodič može kreirati novu turu. Prilikom kreiranja, vodič unosi sledeće
podatke:
1. Naziv
2. Lokacija: grad i država
3. Opis
4. Jezik (engleski,...)
5. Max broj turista
6. Ključne tačke (tura mora da se sastoji od makar dve ključne tačke, početne i krajnje, a
između njih se može dodati još nekoliko)
7. Datum i vreme početka ture (može se zadati nekoliko datuma i vremena ako se tura
ponavlja više puta)
8. Trajanje (u satima)
9. Jedna ili više slika (za svaku sliku navesti putanju do slike)
    
● Otkazivanje ture: Vodič može izabrati jednu od svojih tura i otkazati je najkasnije 48h pred
početak ture. Svi turisti koji su se prijavili na turu će dobiti vaučer za jednu bilo koju turu
koju mogu iskoristiti u narednih godinu dana, kako bi se nadoknadila tura koja je otkazana.

● Praćenje ture uživo: Vodič ima uvid u listu tura koje se održavaju danas. Za bilo koju od tih
tura može označiti da je tura počela. Vodič ne može u isto vreme imati nekoliko započetih
tura, već samo jednu. Kada tura počne, vodiču se izlistavaju ključne tačke te ture, pri čemu
on može označiti određene tačke kada se do njih dođe u toku ture (startovanjem ture se
već prva ključna tačka označila). Vodič treba da označi koji turisti iz liste turista su se pojavili
na turi i u kom momentu (koja ključna tačka je bila u toku kada se turista pridružio turi).
Kada se tura završi, vodič mora označiti da je tura gotova (tura je gotova kada vodič označi
poslednju ključnu tačku ili može to uraditi ranije npr. pritiskom na neko posebno dugme ako
se tura iz neočekivanog razloga završila ranije, pre nego što se stiglo do poslednje ključne
tačke).

● Statistika o turama: Prikazati vodiču jednu od njegovih tura koja je bila najviše posećena
generalno (za sva vremena) ili u izabranoj godini. Posećenost se gleda spram broja ljudi na
turi. Omogućiti vodiču da odabere jednu od njegovih tura kako bi video statistiku o turistima
koji su prisustvovali turi. Prikazati broj turista određene starosne grupe (koliko je bilo turista
ispod 18 godina, između 18 i 50, i iznad 50). Sve ture koje se prikazuju u statistikama moraju
biti završene ture.

● Otkaz: Vodič ima opciju da da otkaz. Sve unapred zakazane ture ovog vodiča će biti
otkazane, i turistima će biti dodeljen po jedan vaučer za svaku turu koju su zakazali kod ovog
vodiča. Vaučer mogu iskoristiti na bilo koje ture u naredne 2 godine. Pored toga, ako postoje
turisti koji od ranije imaju osvojen vaučer baš za ture ovog vodiča, ti vaučeri tada dobijaju
mogućnost da se iskoriste za bilo koje ture, a ne samo za ture ovog vodiča.

● Prikaz recenzija: Kada se tura završi, vodič može videti ocene koje je dobio od turista. Za
svakog turistu može videti i kada se priključio turi (u toku koje ključne tačke), te može
prijaviti njegovu recenziju ukoliko je napisao nešto o delu ture na kom nije prisustvovao.
Pored recenzije tog turiste će stajati oznaka da je recenzija nevalidna.

● Super-vodič: Vodič može postati super-vodič za neki jezik (npr. engleski) ukoliko ima bar 20
vođenih tura u poslednjih godinu dana na tom jeziku, a da je prosek ocena na turama u
poslednjih godinu dana na tom jeziku iznad 4.0. Super-vodič znači da će sve ture ovog
vodiča biti prve prikazane turistima prilikom prikaza ili pretrage tura, kao i da će biti posebno
naznačene turistima. Ako u narednoj godini vodič ne ispuni 20 tura na tom jeziku i ne zadrži
prosek 4.0, gubi se status super-vodiča.

● Prihvatanje zahteva za turu: Vodič može da vidi sve zahteve za turu i da ih filtrira po
sledećim parametrima: lokacija, broj ljudi, jezik i datum. Ako odabere datum, unosi opseg
datuma i izlistavaju mu se svi zahtevi za ture koji su obuhvaćeni njegovim zadatim opsegom.
Ako vodič prihvati turu, određuje termin u opsegu datuma koje je turista naveo. Vodič mora
biti slobodan u tom terminu tj. ne sme imati već isplaniranu neku turu u tom terminu. Turisti
se šalje obaveštenje da je tura prihvaćena i termin koji je vodič odredio.

● Prihvatanje dela ture u zahtevu za složenu turu: Vodič može prihvatiti samo jedan deo
ture u zahtevu za složenu turu, kako bi se pružila prilika i drugim vodičima da preuzmu
ostale delove. Pošto je turista zadao željeni opseg datuma kada bi se neki deo ture mogao
organizovati, sistem treba da onemogući vodiču da se prijavi na delove ture u kojima nema
slobodne termine. Za delove ture za koje je vodič slobodan, sistem treba da izlista moguće
termine kada bi se taj deo ture mogao organizovati (tj. kada je vodič slobodan da održi taj
deo ture) i ti termini se ne smeju preklapati sa terminima već prihvaćenih delova iste ove
složene ture (npr. ako je turista naveo iste opsege datuma za svaki deo ture, moglo bi doći
do preklapanja termina različitih delova ture, te treba voditi računa o tome). Vodič može
odabrati jedan od predloženih termina i time prihvatiti vođenje dela ture.

● Statistika o zahtevima za ture: Statistika o zahtevima za ture se pravi spram svih zahteva, a
ne spram zahteva koje je vodič prihvatio. Vodič može odabrati određenu lokaciju ili jezik i
videti broj zahteva za ture na toj lokaciji ili na tom jeziku. Ovaj broj zahteva se može prikazati
na nivou godina ili ako vodič odabere neku konkretnu godinu, onda na nivou meseci u toj
izabranoj godini.

● Kreiranje ture spram statistike o zahtevima za ture: Sistem treba da da predlog vodiču da
kreira turu za najtraženiju lokaciju ili jezik. Najtraženija lokacija ili jezik se posmatra na
osnovu zahteva za ture napravljenih u poslednjih godinu dana. Vodič može prihvatiti predlog
sistema i nastaviti kreiranje ture popunjavajući ostale podatke koje inače unosi kada kreira
turu (dok će lokacija ili jezik već unapred biti podešeni).

4 TURISTA

● Prikaz i pretraga tura: Turista može pregledati sve ponuđene ture ili ih pretražiti po
sledećim parametrima:
1. Lokacija: grad i država
2. Trajanje ture
3. Jezik
4. Broj ljudi (prilikom pretrage treba voditi računa da ovaj broj ne prelazi max broj turista koji
je vodič zadao)

● Rezervacija ture: Turista bira jednu od tura, broj osoba koje bi išle na turu i informacije o
svakoj osobi (npr: ime, prezime, godine). Sistem proverava da li je ta tura već popunjena i
javlja turisti ukoliko nema mesta za odabrani broj ljudi. Pored toga, ispisuje se broj mesta koji
je još uvek slobodan, ukoliko tura nije u potpunosti popunjena. Turista može promeniti broj
ljudi ili odustati od ture (odustati od kreiranje rezervacije). Ako je tura potpuno popunjena,
sistem će ponuditi druge ture na istoj lokaciji. Turista može pokušati da rezerviše neku od
ponuđenih alternativnih tura (unoseći broj osoba i informacije o osobama ponovo) ili
odustati. Kada se rezerviše tura, voditi računa da se smanji broj slobodnih mesta koje ostaju
na toj turi.

● Prisustvo na turi: Turista može pratiti do koje ključne tačke je stigla neka tura na koju se
prijavio, a koja je trenutno aktivna (vodič ju je pokrenuo i beleži ključne tačke na kojima se
nalazi). Kada se turista priključi turi i vodič zabeleži njegovo prisustvo i prisustvo turista koje
je on prijavio na turu, turisti stiže obaveštenje koje osobe je vodič dodao kao prisutne na
turi.

● Ocenjivanje ture i vodiča: Kada se završi tura na kojoj je turista bio (označen od strane
vodiča da je prisustvovao i potvrđeno od strane turiste), turista može oceniti turu. Turista
popunjava nekoliko kategorija pri ocenjivanju: znanje vodiča (1-5), jezik vodiča (1-5),
zanimljivost ture (1-5) i dodatan komentar. Turista može ostaviti jednu ili više slika sa ture
(za svaku sliku navesti putanju do slike).

● Prikaz i kreiranje zahteva za turu: Turista može da kreira zahtev za posebnu turu i traži
vodiče koji bi ovo organizovali. Nakon kreiranja zahteva za turu, turista može videti kreiran
zahtev u listi svih svojih zahteva za turu. Taj zahtev ima status "na čekanju", sve dok ga neki
vodič ne prihvati. Ukoliko 48h pred odabrani opseg datuma nijedan vodič nije prihvatio turu,
zahtev za turu postaje "nevažeći". Kada neki vodič prihvati turu, zahtev postaje "prihvaćen",
turisti stiže obaveštenje i on može videti termin koji je vodič zadao.
Turista kreira zahtev za turu tako što navodi:
1. Lokaciju: grad i državu
2. Opis
3. Jezik
4. Broj ljudi i informacije o njima (ime, prezime, godine...)
5. Opseg datuma u kom bi se tura organizovala
   
● Statistika o zahtevima za ture: Turista može videti statistiku o njegovim zahtevima za ture
(samo obične ture, ne složene ture). Turista može videti procenat zahteva koji su prihvaćeni
od strane vodiča i procenat onih koji nisu (generalno za sva vremena ili za odabranu godinu).
Omogućiti turisti prikaz broja zahteva spram jezika (npr. x-osa jezik ture, y-osa broj zahteva).
Isto to uraditi i za lokaciju. Prikazati prosečan broj ljudi u zahtevima koji su prihvaćeni
(generalno za sva vremena ili za odabranu godinu).

● Obaveštenje o novim turama: Kada vodiči naprave nove ture na osnovu zahteva za ture (u
funkcionalnosti “Kreiranje ture spram statistike o zahtevima za ture”), sistem treba da
proveri da li te nove ture imaju lokaciju ili jezik kao neki zahtev turiste koji nikada nije bio
ispunjen (npr. mnogo turista je pravilo zahteve za ture na norveškom jeziku; vodiči su
napravili nove ture spram ovih zahteva; biće obavešteni turisti koji među svojim
neispunjenim zahtevima imaju one koji imaju jezik norveški). Pored obaveštenja, turista će
moći da vidi podatke o ovoj novoj kreiranoj turi.

● Prikaz i kreiranje zahteva za složene ture: Turista može da kreira zahtev za složenu turu i
traži vodiče koji bi ovo organizovali. Složena tura se sastoji od više običnih tura, te je
zapravo potrebno uneti sve iste podatke kao u funkcionalnosti “Prikaz i kreiranje zahteva za
turu”, samo za svaki deo ove složene ture. Nakon kreiranja zahteva za složenu turu, turista
može videti kreiran zahtev u listi svih svojih zahteva za složene ture. Taj zahtev ima status
"na čekanju", sve dok vodiči ne prihvate svaki deo složene ture. Ukoliko 48h pred odabrani
opseg datuma za prvi deo ture nijedan vodič nije prihvatio neki deo ture, zahtev za složenu
turu postaje "nevažeći". Ako su svi vodiči prihvatili sve delove ture, zahtev postaje
"prihvaćen".
Turista kreira zahtev za složenu turu tako što za svaki deo ture navodi:
1. Lokacija
2. Opis
3. Jezik
4. Broj ljudi i informacije o njima (ime, prezime, godine...)
5. Opseg datuma
   
● Delimično prihvaćene složene ture: Omogućiti turisti da u listi svojih zahteva za složene
ture vidi sve delove jedne odabrane složene ture. Za svaki deo je potrebno prikazati statuse
"na čekanju" i "prihvaćen". Samo oni delovi ture koji su prihvaćeni od strane vodiča će imati
status "prihvaćen". Pored statusa, turista će videti i koji termin je vodič zadao kada je
prihvatio deo ture.

● Osvajanje vaučera: Turista može osvojiti vaučer ukoliko u godinu dana ode na 5 bilo kojih
tura. Ovako osvojeni vaučeri traju 6 meseci i mogu se iskoristiti za bilo koju turu.

● Prikaz i upotreba vaučera: Turista može videti sve vaučere koje je dobio (zbog toga što je
vodič otkazao turu, dao otkaz ili je turista osvojio vaučer) i do kada se svaki od vaučera
može iskoristiti. Prilikom rezervacije neke sledeće ture, turisti će se prikazati svi vaučeri koji
su još uvek važeći, te može odabrati jedan od njih. Kada vaučer istekne, biće izbrisan iz liste
vaučera.
