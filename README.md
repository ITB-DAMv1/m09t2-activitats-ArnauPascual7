[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/LXcrfC_Y)

# m09t2-activitats-ArnauPascual7

## Exercicis

### 1. Investiga la llibreria System.Diagnostics. Enumera i explica els m�todes i propietats m�s rellevants o �tils que trobis.

System.Diagnostics �s un namespace que proporciona classes que permeten interactuar amb processos del sistema, registrar events i contadors de rendiment.

La classe **Activity** cont� permet veure les operacions que est� realitzant el sistema. Les operacions s�n peticions o crides a diferents sistemes o protocols. M�todes i propietats destacades:
- Current: Per obtenir o establir l'operaci� actual de l'activitat.
- Events: Per veure tots els events d'una operaci� de l'activitat.
- OperationName: Per veure el nom de l'operaci� de l'activitat.
- Start(): Per a iniciar una activitat.
- Stop(): Per a parar una activitat.
- SetStartTime(DateTime): Per a establir una hora d'inici.
- AddEvent(ActivityEvent): Permet afegir events a una activitat.

La classe **Debug** proporciona m�todes per a ajudar a depurar el codi, amb aquesta classe �s possible imprimir informaci� de depuraci� y comprobar la l�gica sense afectar el rendiment. M�todes i propietats destacades:
- Assert(Boolean): Comprova una condici� i si �s falsa mostra un recuadre de missatge d'error en la pila de crides.
- Fail(String): Permet enviar un missatge d'error i amb Fail(String, String) un missatge d'error una descripci� m�s detallada.
- WriteLine(String): Escriu un missatge i un salt de l�nea en els ajents de segument de la col�lecci� Listeners, Output Window

La classe **FileVersionInfo** permet veure les versions dels arxius executables. M�todes i propietats destacades:
- CompanyName: Per obtenir el nom de la companyia que ha creat el fitxer.
- FileVersion: Per obtenir la versi�.
- GetVersionInfo(String): Per a obtenir la versi� del fitxer en format FileVersion.

La classe **Trace** proporciona m�todes i propietats per realitzar un seguiment de la excuci� del codi. M�todes i propietats destacades:
- Indent(): Aumenta el nivell de sangr�a (nivell de sangr�a = tabulacions).
- Unindent(): Disminueix el nivell de sangr�a.
- TraceError(String): Escriu un missatge d'error en els ajents de seguiment de la col�lecci� Listeners.
- TraceWarning(String): Escriu un missatge d'advertencia en els ajents de seguiment de la col�lecci� Listeners.
- WriteLine(Object): Escriu un missatge i un salt de l�nea en els ajents de segument de la col�lecci� Listeners.

### 2. Realitza un programa que imprimeixi per pantalla tots el nom i el PID (Process ID) que estan en execuci� de la m�quina que est�s fent servir. Guarda aquesta llista en un arxiu de text.

Exercici en el Projecte Ex2 de la soluci�.

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

### 3. Executa un programa browser (Edge, Chrome, Firefox). Fent servir la classe ProcessThread i amb del programa anterior crea un m�tode que llista els fils que t� el browser i imprimeix el seu ID, hora d�inici i prioritat. Si obres m�s d�una pestanya, s�obren nous fils? Explica que succeix.

Exercici en el Projecte Ex3 de la soluci�.

```
public static void ListBrowserThreads(string browser)
{
    var processes = Process.GetProcessesByName(browser);

    foreach (Process proc in processes)
    {
        Console.WriteLine($"\nPID: {proc.Id,-13} Proc�s: {proc.ProcessName}");

        foreach (ProcessThread th in proc.Threads)
        {
            Console.WriteLine($"Fil ID: {th.Id,-10} Hora d'inici: {th.StartTime,-20} Proritat: {th.PriorityLevel}");
        }
    }
}
```

En obrir una nova pestanya es poden crear nous fils en el proc�s o directament un proc�s nou, ja que els navegadors utilitzen un model multiproc�s.

### 4. Investiga la classe Thread. Quins m�todes en destacaries? Fes un quadre comparatiu amb Task.

M�todes destacats de la classe Thread:
- Abort(): Est� obsolet, per� permet acabar un fil.
- Join(): Fa que un fil esperi a un altre a que acabi.
- Sleep(Int32): Fa que un fil s'esperi un temps a continuar la seva execusi�.
- Start(): Comen�a l'execusi� del fil.

| | Thread | Task |
| --- | --- | --- |
| Funci� | Gestionar manualment els fils d'execusi�. | Realitzar operacions as�ncrones que poden utilitzar fils. |
| Rendiment | Menys eficient per operacions petites. | Optimitzat per a operacions petites i m�ltiples. |
| Cancel�laci� | Complicada amb Abort(), un m�tode obsolet. | F�cil amb CancellationToken. |
| Fils | �s possible controlar el fil exacte. | No �s possible controlar el fil que s'est� utilitzant. |
| Exemples d'us | Jocs, on cal control sobre els fils en temps real. | APIs

### 5. Crea un programa amb 5 fils que escriuen per consola: $�Hola! Soc el fil n�mero {numeroFil}�

#### a) Executa els 5 fils  i comprova l�ordre que s�imprimeix. Quin �s? i per qu� es aquest ordre?

Exercici en el Projecte Ex5 de la soluci�.

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
    Console.WriteLine($"Hola! Soc el fil n�mero {th}");
}
```

Els fils no s'imprimeixen en cap ordre concret, cada execuci� �s diferent. El sistema opertiu �s qui decideix quin fil va abans que un altre, aquest es basa en la c�rrega de la CPU d'entre d'altres coses.

#### b) Fes servir la funci� .Sleep() per mirar de fer que les tasques s�executin en ordre invers.

Exercici en el Projecte Ex5 de la soluci�.

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
    Console.WriteLine($"Hola! Soc el fil n�mero {th}");
}
```

### Carrera de camells! Realitza un programa que emuli una carrera de camells. Cada camell �s un thread diferent. Els camells han de comptar de 0 a 100. A cada comptatge escriu per consola el n�mero de camell i el n�mero pel qual va, a m�s a m�s descansar� X milisegons. X ser� un n�mero aleatori  a cada cicle d�entre dos valors. Els dos valors s�n par�metres diferents entre els camells.

Exercici en el Projecte Ex6 de la soluci�.

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