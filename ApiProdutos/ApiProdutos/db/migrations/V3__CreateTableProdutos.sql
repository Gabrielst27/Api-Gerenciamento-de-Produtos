CREATE SEQUENCE IF NOT EXISTS public.produtos_prod_id_seq
    INCREMENT 1
    START 1;

CREATE TABLE IF NOT EXISTS public.produtos
(
    prod_id bigint NOT NULL DEFAULT nextval('produtos_prod_id_seq'::regclass),
    prod_codinterno character varying(30) COLLATE pg_catalog."default" NOT NULL,
    prod_nome character varying(60) COLLATE pg_catalog."default" NOT NULL,
    prod_descricao character varying(150) COLLATE pg_catalog."default",
    prod_peso real,
    prod_largura real,
    prod_comprimento real,
    prod_altura real,
    prod_cor_principal character varying(30) COLLATE pg_catalog."default",
    prod_cor_secundaria character varying(30) COLLATE pg_catalog."default",
    prod_data_cadastro timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    prod_preco_custo numeric(15,0) NOT NULL,
    prod_preco_min numeric(15,0) NOT NULL,
    prod_estoque_total integer,
    prod_categ_id bigint,
    prod_subcateg_id bigint,
    CONSTRAINT produtos_pkey PRIMARY KEY (prod_id),
    CONSTRAINT produtos_prod_categ_id_fkey FOREIGN KEY (prod_categ_id)
        REFERENCES public.categorias (categ_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT produtos_prod_subcateg_id_fkey FOREIGN KEY (prod_subcateg_id)
        REFERENCES public.subcategorias (subcateg_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)