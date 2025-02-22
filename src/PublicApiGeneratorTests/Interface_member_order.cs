using PublicApiGeneratorTests.Examples;

namespace PublicApiGeneratorTests
{
    public class Interface_member_order : ApiGeneratorTestsBase
    {
        [Fact]
        public void Should_output_in_known_order_and_alphabetically()
        {
            // Yes, CodeDOM inserts public for events...
            AssertPublicApi<IInterfaceMemberOrder>("""
namespace PublicApiGeneratorTests.Examples
{
    public interface IInterfaceMemberOrder
    {
        int IProperty1 { get; set; }
        int Property1 { get; set; }
        int Property2 { get; set; }
        int iProperty2 { get; set; }
        event System.EventHandler Event1;
        event System.EventHandler Event2;
        event System.EventHandler IEvent1;
        event System.EventHandler iEvent2;
        void IMethod1();
        void Method1();
        void Method2();
        void iMethod2();
    }
}
""");
        }
    }

    namespace Examples
    {
        public interface IInterfaceMemberOrder
        {
            event EventHandler Event2;
            event EventHandler Event1;
            event EventHandler iEvent2;
            event EventHandler IEvent1;

            int Property2 { get; set; }
            int Property1 { get; set; }
            int iProperty2 { get; set; }
            int IProperty1 { get; set; }

            void Method2();
            void Method1();
            void iMethod2();
            void IMethod1();
        }
    }
}
