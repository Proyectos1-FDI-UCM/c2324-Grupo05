using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Interface for the command pattern
public interface ICommand
{
    void Execute(); // Execute the command
    void Undo(); // Undo the command
}