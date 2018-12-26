using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    class MessageLogFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "Журнал сообщений";
            }
        }

        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            return new MessageLog();
        }
    }
}
