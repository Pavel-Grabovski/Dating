CREATE TABLE user_preferences
(
    id uuid NOT NULL,
    gender gender,
    year_birth_from integer NOT NULL CHECK (year_birth_from > 1900),
    year_birth_to integer NOT NULL CHECK (year_birth_to > 3000),
    search_radius integer NOT NULL CHECK (search_radius > 0),
    having_children bool
)