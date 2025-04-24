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
- WriteLine(String): Escriu un missatge i un salt de l�nea en els ajents de segument de la col�lecci� Listeners, Output Window.

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

### Realitza un programa que imprimeixi per pantalla tots el nom i el PID (Process ID) que estan en execuci� de la m�quina que est�s fent servir. Guarda aquesta llista en un arxiu de text.

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