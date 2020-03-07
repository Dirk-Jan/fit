#!/usr/bin/perl --
use 5.010;
use strict;
use warnings;

opendir my $dir, './' or die "Cannot open directory: $!";
my @files = readdir $dir;
closedir $dir;

# Regex
# @files = grep(!/^\.{1,2}/, @files);
# @files = grep('component.{*}\.(ts|css|html)', @files);
@files = grep(/^(?!\.{1,2}).*component\.(ts|html|css|spec\.ts)/, @files);

# print join(", ", @files);

foreach (@files) {
    print "\n";
    print "\n";
    print($_);
    print "\n";
    
    open my $in, '<', $_ or die "Can't read old file: $!";
    # open my $out, '>', "$_.new" or die "Can't write new file: $!";

    # print $out "# Add this line to the top\n"; # <--- HERE'S THE MAGIC

    while( <$in> )
    {
        print $_;
        # .PageComponent
        $_ =~ s/\.PageComponent/Page/;
        print $_;
        # print $out $_;
    }

    # close $out;
    close $in;
}

