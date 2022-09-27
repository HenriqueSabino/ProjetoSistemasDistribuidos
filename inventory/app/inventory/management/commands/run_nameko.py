import yaml
import logging
from django.core.management.base import BaseCommand
from nameko.cli import run


logger = logging.getLogger(__name__)


class Command(BaseCommand):
    """Django command to wait for the database"""

    def add_arguments(self, parser):
        parser.add_argument(
            '-c',
            '--config',
            type=str,
            help='Nameko service onfiguration file.'
        )
        parser.add_argument(
            '-s',
            '--services',
            type=str,
            help='Target service module.'
        )

    def handle(self, *args, **options):
        with open(options['config']) as f:
            config = yaml.safe_load(f)

        if "LOGGING" in config:
            logging.config.dictConfig(config['LOGGING'])
        else:
            logging.basicConfig(level=logging.INFO, format='%(message)s')

        services = []
        for path in options['services'].split():
            services.extend(
                run.import_service(path)
            )
        run.run(services, config)
