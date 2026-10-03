# ENFORCER  
### Projekt gry  
**(1.10.2026 r.)**

---

## 1. Wstęp

### 1.1 Zakres  
Dokument opisuje podstawowe założenia projektu gry **ENFORCER** – systemy, narzędzia, struktura rozgrywki, mechaniki oraz elementy fabularne.  

---

## 2. Systemy docelowe

### 2.1 Windows  
Gra będzie dostępna na systemach Windows 10 oraz Windows 11. Architektura: 64-bit, tryb uruchamiania w oknie lub pełnoekranowy. Wsparcie dla DirectX 11 lub 12 z założenia wdrożone przez silnik gry. Występować będzie obsługa klawiatury i myszy.

### 2.2 Android  
Gra będzie dostępna na urządzeniach mobilnych z systemem Android, optymalizowana pod ekrany dotykowe.

---

## 3. Systemy deweloperskie

### 3.1 Oprogramowanie  
Do tworzenia gry wykorzystywane będą następujące narzędzia, wymienione poniżej.
- **Silnik gry:** Unity 6000.6.2f1 / Unity 6000.6.3f1
- **IDE:** Visual Studio 2026 / Visual Studio Code (Community Version)  
- **Grafika:** Photoshop, Aseprite
- **Kontrola wersji:** Github Desktop
- **Zarządzanie projektem:** Discord  
- **Audio:** Audacity, FL Studio 

---

## 4. Dokumentacja

### 4.1 Koncept  
ENFORCER to gra typu run-and-gun w stylu pixel 2D. Fundamentem jest dynamiczna rozgrywka, w której gracz wciela się w funkcjonariusza policji w niebezpiecznym środowisku miasta Tanzer City. Koncept zakłada połączenie prostych zasad z rosnącą złożonością świata.

### 4.2 Fabuła  
Fabuła stanowi tło dla działań gracza. Akcja odbywa się w latach 2060 w Ameryce Północnej. Przez ogólnopowszechną korupcję w Wolnym Mieście Tanzer, służby i korporacje przymykają oko na działalność przestępczą odbywającą się na całym terytorium. Gracz wciela się w postać policjanta pracującego w niezależnym oddziale specjalnym Tanzer City Police Deparment, Randalla Benneta. Ogólny zarys obejmuje sytuacje kryzysowe, w której gracz pełni rolę funkcjonariusza organów ściganie i eliminacji zagrożeń.

### 4.3 Struktura gry  
Struktura gry opiera się na podziale na poziomy. Każda sekcja rozgrywki wprowadza inny scenariusz, innych przeciwników lub mechaniki. Gra umożliwia płynne przechodzenie między etapami oraz stopniowe zwiększanie trudności.

### 4.4 Gracz  
Gracz wciela się w postać o stałym zestawem umiejętności i uzbrojeniem, które może być rozwijane w trakcie gry. Postać posiada określone statystyki oraz możliwości interakcji ze światem.

### 4.5 Działanie  
Mechaniki gry obejmują poruszanie się, interakcję z obiektami, walkę oraz wykonywanie zadań. System działania powinien być intuicyjny, a jednocześnie dawać przestrzeń na rozwój bardziej zaawansowanych funkcji w przyszłości.

### 4.6 Cele  
Cele gry obejmują wykonywanie misji, eliminację zagrożeń lub osiąganie określonych wyników. Przede wszystkim, ukończenie fabuły. Gracz powinien mieć jasność, co jest jego aktualnym zadaniem oraz jakie są długoterminowe cele rozgrywki.

---

## 5. Frontend

### 5.1 Wstęp  
Oprócz standartowego ekranu "Made in Unity" gra będzie również zawierała tytułowy ekran startowy, po którym gracz zostanie wczytany do właściwego menu.

### 5.2 Menu  
Menu główne zawiera podstawowe opcje: rozpoczęcie gry, ustawienia, wyjście oraz ewentualnie dostęp do profilu gracza. Podmenu ustawień obejmuje głównie audio i sterowanie, a także dwie opcje językowe: polski oraz angielski.

---

## 6. Gameplay

### 6.1 Świat  
Świat gry jest podzielony na obszary o różnym charakterze. Każdy obszar posiada unikalne elementy wizualne oraz zestaw interakcji. Świat powinien być spójny i logiczny w swojej konstrukcji.

### 6.2 Widok  
Gra wykorzystuje widok 2D od boku. Kamera powinna zapewniać dobrą czytelność otoczenia oraz obiektów interaktywnych. Tło będzie zróżnicowane w zależności od aktualnego poziomu, na którym znajduje się gracz.

### 6.3 Powierzchnie  
Powierzchnie obejmują różne typy podłoża, przeszkód i elementów środowiskowych. Mogą wpływać na ruch gracza lub przeciwników. Projekt powierzchni powinien wspierać czytelność i dynamikę rozgrywki.

### 6.4 Typy obiektów  
Obiekty dzielą się na interaktywne, dekoracyjne, funkcjonalne oraz przeciwników. Każdy typ posiada określone właściwości i zachowania. System obiektów powinien być łatwy do rozszerzania.

### 6.5 Przeciwnicy  
Przeciwnicy stanowią główne zagrożenie dla gracza. Każdy typ przeciwnika posiada unikalne zachowania, statystyki oraz sposób ataku. Ich projekt powinien wspierać różnorodność wyzwań.

### 6.6 Sterowanie  
- [A/D] - Poruszanie się
- [S] - Kucanie
- [Space] - Skok
- [F] - Strzelanie
- [R] - Zmiana broni

---

## 7. Drużyna 
- Kamil Gabryliszyn
- Igor Ryczek
- Tymur Panasii

---

## 8. Ramki czasowe  
1.10.2026 - Stworzenie projektu
30.11.2026 ~ Pierwszy milestone
15.02.2027 ~ Drugi milestone
13.04.2027 ~ Trzeci milestone
13.04.2027 - Koniec etapu pracy nad projektem (do SCI++)

