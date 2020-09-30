using MvvmHelpers;
using Novus.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Novus.ViewModels
{
    class SignOnViewModel : BaseViewModel
    {
        public SignOnViewModel()
        {
            units = Unit.GenerateUnits(4);
        }

        ObservableCollection<Unit> units;
        public ObservableCollection<Unit> Units
        {
            get => units;
            set
            {
                SetProperty(ref units, value);
                OnPropertyChanged(nameof(Student));
            }
        }

        public void SetIsVisible(int unitID)
        {
            for (int i= 0; i < Units.Count; i++)
            {
                if(unitID == Units[i].UnitID)
                {
                    Unit newUnit = Units[i];
                    newUnit.IsVisible = !Units[i].IsVisible;
                    Units[i] = newUnit;
                    return;
                }
            }
        }

        public void RegisterForLecture(string tag)
        {
            try
            {
                string[] tagSplit = tag.Split('|');
                for (int i = 0; i < Units.Count; i++)
                {
                    if (Units[i].UnitID.ToString() == tagSplit[0])
                    {
                        for (int x = 0; x < Units[i].Lectures.Count; x++)
                        {
                            if (Units[i].Lectures[x].ClassID.ToString() == tagSplit[1])
                            {
                                for (int y = 0; y < Units[i].Lectures.Count; y++)
                                {
                                    if (x != y)
                                    {
                                        Class newClass = Units[i].Lectures[y];
                                        newClass.Registerd = false;
                                        Units[i].Lectures[y] = newClass;
                                    }
                                }
                                return;
                            }
                        }
                    }
                }
            } catch (Exception)
            {
                return;
            }
            
        }

        public void RegisterForTutorial(string tag)
        {
            try
            {
                string[] tagSplit = tag.Split('|');
                for (int i = 0; i < Units.Count; i++)
                {
                    if (Units[i].UnitID.ToString() == tagSplit[0])
                    {
                        for (int x = 0; x < Units[i].Tutorials.Count; x++)
                        {
                            if (Units[i].Tutorials[x].ClassID.ToString() == tagSplit[1])
                            {
                                for (int y = 0; y < Units[i].Tutorials.Count; y++)
                                {
                                    if (x != y)
                                    {
                                        Class newClass = Units[i].Tutorials[y];
                                        newClass.Registerd = false;
                                        Units[i].Tutorials[y] = newClass;
                                    }
                                }
                                return;
                            }
                        }
                    }
                }
            } catch (Exception)
            {
                return;
            }

        }
    }
}
