﻿from Module import Module
from TestController import TestController
from TestPacket import TestPacket

class TestModule(Module):
	def __init__(self):
		Module.__init__(self)
		self.ServiceId = "Test"

	def Initialize(self,server,cacheManager,controllerComponentManager):
		Module.Initialize(self,server,cacheManager,controllerComponentManager)
		self.AddController(lambda :TestController())
		self.AddPacket("ITestPacket",lambda :TestPacket())