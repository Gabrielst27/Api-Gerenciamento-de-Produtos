CREATE SEQUENCE IF NOT EXISTS public.contratos_contr_id_seq
    INCREMENT 1
    START 1;

CREATE TABLE IF NOT EXISTS public.contratos
(
    contr_id bigint NOT NULL DEFAULT nextval('contratos_contr_id_seq'::regclass),
    contr_codinterno character varying(30) COLLATE pg_catalog."default" NOT NULL,
    contr_valor_inicial decimal(15,2) NOT NULL,
    contr_valor_mensal decimal(15,2) NOT NULL,
    contr_reajuste decimal(5,2) NOT NULL,
    contr_tipo character varying(20) COLLATE pg_catalog."default" NOT NULL,
    contr_representante character varying(60) COLLATE pg_catalog."default" NOT NULL,
    contr_data_inicial timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    contr_dia_cobranca timestamp without time zone NOT NULL,
    contr_data_expira timestamp without time zone NOT NULL,
    contr_emp_id bigint,
    CONSTRAINT contratos_pkey PRIMARY KEY (contr_id),
    CONSTRAINT contratos_contr_emp_id_fkey FOREIGN KEY (contr_emp_id)
        REFERENCES public.fornecedores (fornec_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

CREATE SEQUENCE IF NOT EXISTS public.fornecedores_fornec_id_seq
    INCREMENT 1
    START 1;

CREATE TABLE IF NOT EXISTS public.fornecedores
(
    fornec_id bigint NOT NULL DEFAULT nextval('fornecedores_fornec_id_seq'::regclass),
    fornec_codinterno character varying(30) COLLATE pg_catalog."default" NOT NULL,
    fornec_cnpj character varying(14) COLLATE pg_catalog."default" NOT NULL,
    fornec_razao_social character varying(60) COLLATE pg_catalog."default" NOT NULL,
    fornec_fantasia character varying(60) COLLATE pg_catalog."default",
    fornec_status integer NOT NULL,
    fornec_data_cadastro timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    fornec_cep character varying(8) COLLATE pg_catalog."default" NOT NULL,
    fornec_logradouro character varying(60) COLLATE pg_catalog."default" NOT NULL,
    fornec_numero integer NOT NULL,
    fornec_complemento character varying(60) COLLATE pg_catalog."default",
    fornec_bairro character varying(60) COLLATE pg_catalog."default" NOT NULL,
    fornec_cidade character varying(40) COLLATE pg_catalog."default" NOT NULL,
    fornec_uf character varying(4) COLLATE pg_catalog."default" NOT NULL,
    fornec_pais character varying(56) COLLATE pg_catalog."default" NOT NULL,
    fornec_tel1 bigint NOT NULL,
    fornec_tel2 bigint,
    fornec_tel3 bigint,
    fornec_email character varying(60) COLLATE pg_catalog."default" NOT NULL,
    fornec_contr_id bigint,
    CONSTRAINT fornecedores_pkey PRIMARY KEY (fornec_id),
    CONSTRAINT fornecedores_fornec_contr_id_fkey FOREIGN KEY (fornec_contr_id)
        REFERENCES public.contratos (contr_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

COMMIT;