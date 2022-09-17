from sqlalchemy import Column, DateTime, ForeignKey, String

from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy.orm import relationship

from inventory.database import Base


class Store(Base):
    __tablename__ = 'stores'

    id = Column(UUID(as_uuid=True), primary_key=True, index=True)
    city_id = Column(UUID(as_uuid=True), ForeignKey('city.id'))
    name = Column(String(length=50))
    created_at = Column(DateTime)

    city = relationship('City')
