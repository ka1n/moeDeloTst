CREATE ROLE "a.kirillov" CREATEDB NOINHERIT NOREPLICATION LOGIN PASSWORD 'qweqwe123';

CREATE DATABASE moe_delo
  WITH OWNER = "a.kirillov"
    ENCODING = 'UTF8'
    TABLESPACE = pg_default;
    
CREATE SCHEMA md AUTHORIZATION "a.kirillov";

COMMENT ON SCHEMA md
IS 'Схема для выполнения тестового задания "Моё Дело"';

ALTER SCHEMA md
  OWNER TO "a.kirillov"; 
  
CREATE TABLE md.contragents (
  id BIGSERIAL,
  "IdContragentType" INTEGER,
  CONSTRAINT contragents_pkey PRIMARY KEY(id)
) 
WITH (oids = false);

COMMENT ON COLUMN md.contragents.id
IS 'Идентификатор';

COMMENT ON COLUMN md.contragents."IdContragentType"
IS 'Тип контрагента';

ALTER TABLE md.contragents
  OWNER TO "a.kirillov";
  
  
CREATE TABLE md.individual (
  id BIGSERIAL,
  lastname TEXT,
  firstname TEXT,
  patronymic TEXT,
  "IdContragent" BIGINT,
  CONSTRAINT individual_pkey PRIMARY KEY(id),
  CONSTRAINT individual_fk FOREIGN KEY ("IdContragent")
    REFERENCES md.contragents(id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

COMMENT ON COLUMN md.individual.id
IS 'Идентификатор';

COMMENT ON COLUMN md.individual.lastname
IS 'Фамилия';

COMMENT ON COLUMN md.individual.firstname
IS 'Имя';

COMMENT ON COLUMN md.individual.patronymic
IS 'Отчество';

COMMENT ON COLUMN md.individual."IdContragent"
IS 'Идентификатор контрагента';

ALTER TABLE md.individual
  OWNER TO "a.kirillov";
  
  
CREATE TABLE md.organization (
  id BIGSERIAL,
  name TEXT,
  address TEXT,
  "IdContragent" BIGINT,
  CONSTRAINT organization_pkey PRIMARY KEY(id),
  CONSTRAINT organization_fk FOREIGN KEY ("IdContragent")
    REFERENCES md.contragents(id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

COMMENT ON TABLE md.organization
IS 'Юридические лица';

COMMENT ON COLUMN md.organization.id
IS 'Идентификатор';

COMMENT ON COLUMN md.organization.name
IS 'Наименование юридического лица';

COMMENT ON COLUMN md.organization.address
IS 'Адрес регистрации юридического лица';

COMMENT ON COLUMN md.organization."IdContragent"
IS 'Идентификатор контрагента';

ALTER TABLE md.organization
  OWNER TO "a.kirillov";
  
  
  CREATE TABLE md.documents (
  id BIGSERIAL,
  "IdContragent" BIGINT,
  docnumber TEXT,
  docname TEXT,
  CONSTRAINT documents_pkey PRIMARY KEY(id),
  CONSTRAINT documents_fk FOREIGN KEY ("IdContragent")
    REFERENCES md.contragents(id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

COMMENT ON COLUMN md.documents.id
IS 'Идентификатор';

COMMENT ON COLUMN md.documents."IdContragent"
IS 'Идентификатор контрагента';

COMMENT ON COLUMN md.documents.docnumber
IS 'Номер документа';

COMMENT ON COLUMN md.documents.docname
IS 'Название документа';

ALTER TABLE md.documents
  OWNER TO "a.kirillov";          