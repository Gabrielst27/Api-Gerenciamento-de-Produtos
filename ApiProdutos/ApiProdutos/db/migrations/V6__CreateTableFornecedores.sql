CREATE SEQUENCE IF NOT EXISTS public.fornecedores_fornec_id_seq
    INCREMENT 1
    START 1;

CREATE TABLE IF NOT EXISTS public.fornecedores
(
    fornec_id bigint NOT NULL DEFAULT nextval('fornecedores_fornec_id_seq'::regclass),
    fornec_codinterno character varying(30) COLLATE pg_catalog."default" NOT NULL,
    fornec_cnpj integer NOT NULL,
    fornec_razao_social character varying(60) COLLATE pg_catalog."default" NOT NULL,
    fornec_fantasia character varying(60) COLLATE pg_catalog."default",
    fornec_status character varying(10) COLLATE pg_catalog."default" NOT NULL,
    fornec_data_cadastro timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    fornec_cep integer NOT NULL,
    fornec_logradouro character varying(60) COLLATE pg_catalog."default" NOT NULL,
    fornec_numero integer NOT NULL,
    fornec_complemento character varying(60) COLLATE pg_catalog."default",
    fornec_bairro character varying(60) COLLATE pg_catalog."default" NOT NULL,
    fornec_cidade character varying(40) COLLATE pg_catalog."default" NOT NULL,
    fornec_uf character varying(4) COLLATE pg_catalog."default" NOT NULL,
    fornec_pais character varying(56) COLLATE pg_catalog."default" NOT NULL,
    fornec_tel1 integer NOT NULL,
    fornec_tel2 integer,
    fornec_tel3 integer,
    fornec_categ_id bigint,
    fornec_subcateg_id bigint,
    CONSTRAINT fornecedores_pkey PRIMARY KEY (fornec_id)
)