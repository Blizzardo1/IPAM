using System.Net;

using IPAM;
using Windows.Networking.Connectivity;

namespace IPAM_UnitTests {
    public class Tests {

        private readonly string[] subnets = [
            "0.0.0.0",
            "128.0.0.0",
            "192.0.0.0",
            "224.0.0.0",
            "240.0.0.0",
            "248.0.0.0",
            "252.0.0.0",
            "254.0.0.0",
            "255.0.0.0",
            "255.128.0.0",
            "255.192.0.0",
            "255.224.0.0",
            "255.240.0.0",
            "255.248.0.0",
            "255.252.0.0",
            "255.254.0.0",
            "255.255.0.0",
            "255.255.128.0",
            "255.255.192.0",
            "255.255.224.0",
            "255.255.240.0",
            "255.255.248.0",
            "255.255.252.0",
            "255.255.254.0",
            "255.255.255.0",
            "255.255.255.128",
            "255.255.255.192",
            "255.255.255.224",
            "255.255.255.240",
            "255.255.255.248",
            "255.255.255.252",
            "255.255.255.254",
            "255.255.255.255",
        ];

        private Network network;

        [SetUp]
        public void Setup() {
            network = new Network("UnitTest", new(29)) {
                IPAddresses = [
                    new(IPAddress.Parse("10.0.0.0")) { EnrollmentStatus = Enrollment.Cidr },
                    new(IPAddress.Parse("10.0.0.1")) { EnrollmentStatus = Enrollment.Static },
                    new(IPAddress.Parse("10.0.0.2")) { EnrollmentStatus = Enrollment.Static },
                    new(IPAddress.Parse("10.0.0.3")) { EnrollmentStatus = Enrollment.Leased },
                    new(IPAddress.Parse("10.0.0.4")) { EnrollmentStatus = Enrollment.Leased },
                    new(IPAddress.Parse("10.0.0.5")) { EnrollmentStatus = Enrollment.Leased },
                    new(IPAddress.Parse("10.0.0.6")) { EnrollmentStatus = Enrollment.None },
                    new(IPAddress.Parse("10.0.0.7")) { EnrollmentStatus = Enrollment.Broadcast }
                ]
            };
        }

        [Test]
        public void NetworkIsProper() {
            Assert.Multiple(() => {
                Assert.That(network.Id, Is.Not.EqualTo(Guid.Empty));
                Assert.That(network.Cidr, Is.EqualTo(IPAddress.Parse("10.0.0.0")));
                Assert.That(network.Broadcast, Is.EqualTo(IPAddress.Parse("10.0.0.7")));
                Assert.That(network.Subnet, Is.EqualTo(new Subnet(29)));
                Assert.That(network.IPAddresses, Is.Not.Null);
            });

            Enrollment[] equivalence = [
                        Enrollment.Cidr,
                        Enrollment.Broadcast,
                        Enrollment.None,
                        Enrollment.Leased,
                        Enrollment.Static
            ];

            foreach (IpItemDto items in network.IPAddresses) {
                Assert.That(items.EnrollmentStatus, Is.EquivalentTo(equivalence));
            }

            Assert.Pass();
        }

        [Test]
        public void SubnetPrefixIsProper() {
            for (int i = 0; i <= 32; i++) {
                Subnet subnet = new(i);
                Assert.That(subnet.Mask, Is.EqualTo(IPAddress.Parse(subnets[i])));
            }

            Assert.Pass();
        }
    }
}
