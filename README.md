[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/LXcrfC_Y)

# m09t2-activitats-ArnauPascual7

## Exercicis

### 1. Investiga la llibreria System.Diagnostics. Enumera i explica els mètodes i propietats més rellevants o útils que trobis.

System.Diagnostics és un namespace que proporciona classes que permeten interactuar amb processos del sistema, registrar events i contadors de rendiment.

La classe **Activity** conté permet veure les operacions que està realitzant el sistema. Les operacions són peticions o crides a diferents sistemes o protocols. Mètodes i propietats destacades:
- Current: Per obtenir o establir l'operació actual de l'activitat.
- Events: Per veure tots els events d'una operació de l'activitat.
- OperationName: Per veure el nom de l'operació de l'activitat.
- Start(): Per a iniciar una activitat.
- Stop(): Per a parar una activitat.
- SetStartTime(DateTime): Per a establir una hora d'inici.
- AddEvent(ActivityEvent): Permet afegir events a una activitat.

La classe **Debug** proporciona mètodes per a ajudar a depurar el codi, amb aquesta classe és possible imprimir informació de depuració y comprobar la lógica sense afectar el rendiment. Mètodes i propietats destacades:
- Assert(Boolean): Comprova una condició i si és falsa mostra un recuadre de missatge d'error en la pila de crides.
- Fail(String): Permet enviar un missatge d'error i amb Fail(String, String) un missatge d'error una descripció més detallada.
- WriteLine(String): Escriu un missatge i un salt de línea en els ajents de segument de la col·lecció Listeners, Output Window.

La classe **FileVersionInfo** permet veure les versions dels arxius executables. Mètodes i propietats destacades:
- CompanyName: Per obtenir el nom de la companyia que ha creat el fitxer.
- FileVersion: Per obtenir la versió.
- GetVersionInfo(String): Per a obtenir la versió del fitxer en format FileVersion.

La classe **Trace** proporciona mètodes i propietats per realitzar un seguiment de la excució del codi. Mètodes i propietats destacades:
- Indent(): Aumenta el nivell de sangría (nivell de sangría = tabulacions).
- Unindent(): Disminueix el nivell de sangría.
- TraceError(String): Escriu un missatge d'error en els ajents de seguiment de la col·lecció Listeners.
- TraceWarning(String): Escriu un missatge d'advertencia en els ajents de seguiment de la col·lecció Listeners.
- WriteLine(Object): Escriu un missatge i un salt de línea en els ajents de segument de la col·lecció Listeners.

### Realitza un programa que imprimeixi per pantalla tots el nom i el PID (Process ID) que estan en execució de la màquina que estàs fent servir. Guarda aquesta llista en un arxiu de text.

Exercici en el Projecte Ex2 de la solució.

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