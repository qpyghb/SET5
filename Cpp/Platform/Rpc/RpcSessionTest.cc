#include <boost/asio.hpp>
#include <gtest/gtest.h>
#include <glog/logging.h>
#include <gflags/gflags.h>
#include "Rpc/RpcSession.h"
#include "Rpc/RpcServerMock.h"

namespace Egametang {

class RpcSessionTest: public testing::Test
{
protected:
	boost::asio::io_service ioService;
	int port;
	RpcServerMock mockServer;
	RpcSession session;

public:
	RpcSessionTest():
		ioService(), port(10000),
		mockServer(ioService, port), session(ioService, mockServer)
	{
	}

	virtual ~RpcSessionTest()
	{
	}
};

TEST_F(RpcSessionTest, Test1)
{
}

} // namespace Egametang


int main(int argc, char* argv[])
{
	testing::InitGoogleTest(&argc, argv);
	google::InitGoogleLogging(argv[0]);
	google::ParseCommandLineFlags(&argc, &argv, true);
	return RUN_ALL_TESTS();
}
