CREATE SEQUENCE IF NOT EXISTS public.armazens_amz_id_seq
    INCREMENT 1
    START 1;

CREATE TABLE IF NOT EXISTS public.armazens
(
    amz_id bigint NOT NULL DEFAULT nextval('armazens_amz_id_seq'::regclass),
    amz_codinterno character varying(30) COLLATE pg_catalog."default" NOT NULL,
    amz_nome character varying(60) COLLATE pg_catalog."default" NOT NULL,
    amz_data_cadastro timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT armazens_pkey PRIMARY KEY (amz_id)
)