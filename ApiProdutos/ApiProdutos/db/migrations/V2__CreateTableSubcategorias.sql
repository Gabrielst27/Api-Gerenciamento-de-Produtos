CREATE SEQUENCE IF NOT EXISTS public.subcategorias_subcateg_id_seq
    INCREMENT 1
    START 1;

CREATE TABLE IF NOT EXISTS public.subcategorias
(
    subcateg_id bigint NOT NULL DEFAULT nextval('subcategorias_subcateg_id_seq'::regclass),
    subcateg_nome character varying(60) COLLATE pg_catalog."default" NOT NULL,
    subcateg_data_cadastro timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    subcateg_categ_id bigint NOT NULL,
    CONSTRAINT subcategorias_pkey PRIMARY KEY (subcateg_id),
    CONSTRAINT subcategorias_fkey FOREIGN KEY (subcateg_categ_id)
        REFERENCES public.categorias (categ_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)