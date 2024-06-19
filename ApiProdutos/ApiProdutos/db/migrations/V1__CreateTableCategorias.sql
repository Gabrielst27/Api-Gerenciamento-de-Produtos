CREATE SEQUENCE IF NOT EXISTS public.categorias_categ_id_seq
    INCREMENT 1
    START 1;

CREATE TABLE IF NOT EXISTS public.categorias
(
    categ_id bigint NOT NULL DEFAULT nextval('categorias_categ_id_seq'::regclass),
    categ_nome character varying(60) NOT NULL,
    categ_reajuste1 real,
    categ_reajuste2 real,
    categ_reajuste3 real,
    categ_data_cadastro timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT categorias_pkey PRIMARY KEY (categ_id)
);