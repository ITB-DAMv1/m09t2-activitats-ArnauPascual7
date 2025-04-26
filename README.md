[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/LXcrfC_Y)

# m09t2-activitats-ArnauPascual7

## Exercicis

### 1. Investiga la llibreria System.Diagnostics. Enumera i explica els mùtodes i propietats mùs rellevants o ùtils que trobis.

System.Diagnostics ùs un namespace que proporciona classes que permeten interactuar amb processos del sistema, registrar events i contadors de rendiment.

La classe **Activity** contù permet veure les operacions que estù realitzant el sistema. Les operacions sùn peticions o crides a diferents sistemes o protocols. Mùtodes i propietats destacades:
- Current: Per obtenir o establir l'operaciù actual de l'activitat.
- Events: Per veure tots els events d'una operaciù de l'activitat.
- OperationName: Per veure el nom de l'operaciù de l'activitat.
- Start(): Per a iniciar una activitat.
- Stop(): Per a parar una activitat.
- SetStartTime(DateTime): Per a establir una hora d'inici.
- AddEvent(ActivityEvent): Permet afegir events a una activitat.

La classe **Debug** proporciona mùtodes per a ajudar a depurar el codi, amb aquesta classe ùs possible imprimir informaciù de depuraciù y comprobar la lùgica sense afectar el rendiment. Mùtodes i propietats destacades:
- Assert(Boolean): Comprova una condiciù i si ùs falsa mostra un recuadre de missatge d'error en la pila de crides.
- Fail(String): Permet enviar un missatge d'error i amb Fail(String, String) un missatge d'error una descripciù mùs detallada.
- WriteLine(String): Escriu un missatge i un salt de lùnea en els ajents de segument de la colùlecciù Listeners, Output Window.

La classe **FileVersionInfo** permet veure les versions dels arxius executables. Mùtodes i propietats destacades:
- CompanyName: Per obtenir el nom de la companyia que ha creat el fitxer.
- FileVersion: Per obtenir la versiù.
- GetVersionInfo(String): Per a obtenir la versiù del fitxer en format FileVersion.

La classe **Trace** proporciona mùtodes i propietats per realitzar un seguiment de la excuciù del codi. Mùtodes i propietats destacades:
- Indent(): Aumenta el nivell de sangrùa (nivell de sangrùa = tabulacions).
- Unindent(): Disminueix el nivell de sangrùa.
- TraceError(String): Escriu un missatge d'error en els ajents de seguiment de la colùlecciù Listeners.
- TraceWarning(String): Escriu un missatge d'advertencia en els ajents de seguiment de la colùlecciù Listeners.
- WriteLine(Object): Escriu un missatge i un salt de lùnea en els ajents de segument de la colùlecciù Listeners.

### 2. Realitza un programa que imprimeixi per pantalla tots el nom i el PID (Process ID) que estan en execuciù de la mùquina que estùs fent servir. Guarda aquesta llista en un arxiu de text.

Exercici en el Projecte Ex2 de la soluciù.

```
public static void Main(string[] args)
{
    const string fileName = "processes.txt";
    const string filePath = @"..\..\..\" + fileName;

    if (File.Exists(filePath))
    {
        var processes = Process.GetProcesses();
        List<string> lines = new List<string>();

        foreach (Process proc in processes)
        {
            string line = $"PID: {proc.Id,-10} Nom: {proc.ProcessName}";
            Console.WriteLine(line);
            lines.Add(line);
        }

        File.WriteAllLines(filePath, lines);
        Console.WriteLine("Processos escrits en l'arxiu");
    }
}
```

### 3. Executa un programa browser (Edge, Chrome, Firefox). Fent servir la classe ProcessThread i amb del programa anterior crea un mËtode que llista els fils que tÈ el browser i imprimeix el seu ID, hora díinici i prioritat. Si obres mÈs díuna pestanya, síobren nous fils? Explica que succeix.

Exercici en el Projecte Ex3 de la soluciÛ.

```
public static void ListBrowserThreads(string browser)
{
    var processes = Process.GetProcessesByName(browser);

    foreach (Process proc in processes)
    {
        Console.WriteLine($"\nPID: {proc.Id,-13} ProcÈs: {proc.ProcessName}");

        foreach (ProcessThread th in proc.Threads)
        {
            Console.WriteLine($"Fil ID: {th.Id,-10} Hora d'inici: {th.StartTime,-20} Proritat: {th.PriorityLevel}");
        }
    }
}
```

En obrir una nova pestanya es poden crear nous fils en el procÈs o directament un procÈs nou, ja que els navegadors utilitzen un model multiprocÈs.

### 4. Investiga la classe Thread. Quins mËtodes en destacaries? Fes un quadre comparatiu amb Task.

MËtodes destacats de la classe Thread:
- Abort(): Est‡ obsolet, perÚ permet acabar un fil.
- Join(): Fa que un fil esperi a un altre a que acabi.
- Sleep(Int32): Fa que un fil s'esperi un temps a continuar la seva execusiÛ.
- Start(): ComenÁa l'execusiÛ del fil.

| | Thread | Task |
| --- | --- | --- |
| FunciÛ | Gestionar manualment els fils d'execusiÛ. | Realitzar operacions asÌncrones que poden utilitzar fils. |
| Rendiment | Menys eficient per operacions petites. | Optimitzat per a operacions petites i m˙ltiples. |
| Cancel∑laciÛ | Complicada amb Abort(), un mËtode obsolet. | F‡cil amb CancellationToken. |
| Fils | …s possible controlar el fil exacte. | No Ès possible controlar el fil que s'est‡ utilitzant. |
| Exemples d'us | Jocs, on cal control sobre els fils en temps real. | APIs

### 5. Crea un programa amb 5 fils que escriuen per consola: $ìHola! Soc el fil n˙mero {numeroFil}î

#### a) Executa els 5 fils  i comprova líordre que síimprimeix. Quin Ès? i per quË es aquest ordre?

Exercici en el Projecte Ex5 de la soluciÛ.

```
public static void Main(string[] args)
{
    Thread th1 = new Thread(() => WriteHello(1));
    Thread th2 = new Thread(() => WriteHello(2));
    Thread th3 = new Thread(() => WriteHello(3));
    Thread th4 = new Thread(() => WriteHello(4));
    Thread th5 = new Thread(() => WriteHello(5));

    th1.Start();
    th2.Start();
    th3.Start();
    th4.Start();
    th5.Start();
}

public static void WriteHello(int th)
{
    Console.WriteLine($"Hola! Soc el fil n˙mero {th}");
}
```

Els fils no s'imprimeixen en cap ordre concret, cada execuciÛ Ès diferent. El sistema opertiu Ès qui decideix quin fil va abans que un altre, aquest es basa en la c‡rrega de la CPU d'entre d'altres coses.

#### b) Fes servir la funciÛ .Sleep() per mirar de fer que les tasques síexecutin en ordre invers.

Exercici en el Projecte Ex5 de la soluciÛ.

```
public static void Main(string[] args)
{
    Thread th1 = new Thread(() =>
    {
        Thread.Sleep(4000);
        WriteHello(1);
    });
    Thread th2 = new Thread(() =>
    {
        Thread.Sleep(3000);
        WriteHello(2);
    });
    Thread th3 = new Thread(() =>
    {
        Thread.Sleep(2000);
        WriteHello(3);
    });
    Thread th4 = new Thread(() =>
    {
        Thread.Sleep(1000);
        WriteHello(4);
    });
    Thread th5 = new Thread(() => WriteHello(5));

    th1.Start();
    th2.Start();
    th3.Start();
    th4.Start();
    th5.Start();
}

public static void WriteHello(int th)
{
    Console.WriteLine($"Hola! Soc el fil n˙mero {th}");
}
```

### Carrera de camells! Realitza un programa que emuli una carrera de camells. Cada camell Ès un thread diferent. Els camells han de comptar de 0 a 100. A cada comptatge escriu per consola el n˙mero de camell i el n˙mero pel qual va, a mÈs a mÈs descansar‡ X milisegons. X ser‡ un n˙mero aleatori  a cada cicle díentre dos valors. Els dos valors sÛn par‡metres diferents entre els camells.

Exercici en el Projecte Ex6 de la soluciÛ.

```
public static void Main(string[] args)
{
    Thread c1 = new Thread(() => Race(1, GetMinSleep(), GetMaxSleep()));
    Thread c2 = new Thread(() => Race(2, GetMinSleep(), GetMaxSleep()));
    Thread c3 = new Thread(() => Race(3, GetMinSleep(), GetMaxSleep()));
    Thread c4 = new Thread(() => Race(4, GetMinSleep(), GetMaxSleep()));
    Thread c5 = new Thread(() => Race(5, GetMinSleep(), GetMaxSleep()));

    c1.Start();
    c2.Start();
    c3.Start();
    c4.Start();
    c5.Start();

    c1.Join();
    c2.Join();
    c3.Join();
    c4.Join();
    c5.Join();

    Console.WriteLine("Fi de la cursa");
}

public static void Race(int camelNum, int minSleep, int maxSleep)
{
    Random random = new Random();

    string spaces = new string('\t', (camelNum - 1) * 2);

    for (int i = 0; i <= 100; i++)
    {
        Console.WriteLine($"{spaces}Camell {camelNum}: {i}");
        Thread.Sleep(random.Next(minSleep, maxSleep));
    }

    Console.WriteLine($"\nEl camell {camelNum} ha finalitzat la cursa!\n");
}

public static int GetMinSleep()
{
    return new Random().Next(100, 200);
}
public static int GetMaxSleep()
{
    return new Random().Next(300, 600);
}
```