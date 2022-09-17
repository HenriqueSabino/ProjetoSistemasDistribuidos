import logging

from nameko.rpc import rpc


logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(name)s - %(levelname)s - %(message)s')

logger = logging.getLogger(__name__)


class CheckHealthService:
    name = 'check_health_service'

    @rpc
    def check_health(self):

        return "Service is up and running!"
