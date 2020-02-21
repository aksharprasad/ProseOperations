using System;
using System.Text.RegularExpressions;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.AST;
using Microsoft.ProgramSynthesis.Features;

namespace ProseTutorial
{
    public class RankingScore : Feature<double>
    {
        public RankingScore(Grammar grammar) : base(grammar, "Score")
        {
        }

        [FeatureCalculator(nameof(Semantics.Add), Method = CalculationMethod.FromChildrenNodes)]
        public double Add(VariableNode v, NonterminalNode start, NonterminalNode end)
        {
            int multiple = 1;
            foreach(ProgramNode p in start.Children)
            {
                if (p.Symbol.IsTerminal)
                {
                    multiple *= 10;
                    break;
                }
            }
            foreach (ProgramNode p in end.Children)
            {
                if (p.Symbol.IsTerminal)
                {
                    multiple *= 10;
                    break;
                }
            }
            return (double) start.GetFeatureValue(this) * (double) end.GetFeatureValue(this) * multiple;
        }

        [FeatureCalculator(nameof(Semantics.Multiply), Method = CalculationMethod.FromChildrenNodes)]
        public double Multiply(VariableNode v, NonterminalNode start, NonterminalNode end)
        {
            int multiple = 1;
            foreach (ProgramNode p in start.Children)
            {
                if (p.Symbol.IsTerminal)
                {
                    multiple *= 10;
                    break;
                }
            }
            foreach (ProgramNode p in end.Children)
            {
                if (p.Symbol.IsTerminal)
                {
                    multiple *= 10;
                    break;
                }
            }
            return (double)start.GetFeatureValue(this) * (double)end.GetFeatureValue(this) * multiple;
        }

        [FeatureCalculator(nameof(Semantics.Element))]
        public double Element(double v, double k)
        {
            return k;
        }

        [FeatureCalculator("k", Method = CalculationMethod.FromLiteral)]
        public double K(int k)
        {
            return k;
        }

    }
}